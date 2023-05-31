using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Test_Technique_Backend.Models.Common.Authentication;
using Test_Technique_Backend.Models.Entities;

namespace Test_Technique_Backend.Services.InfraServices.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<Admin> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<Admin> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthenticationService(UserManager<Admin> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<Admin> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {

            AuthenticationResponse response = null;
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                response = new AuthenticationResponse();
                return response;
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                response = new AuthenticationResponse();
                return response;
            }
            
            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            response = new AuthenticationResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName
            };
            return response;
        }
        private async Task<JwtSecurityToken> GenerateToken(Admin user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {

                 new Claim("uid", user.Id),
                 new Claim( ClaimTypes.Name,user.UserName ),
                 new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 new Claim(JwtRegisteredClaimNames.Email, user.Email),
            };
            

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: authClaims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;

        }


    }
}
