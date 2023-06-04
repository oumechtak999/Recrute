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
        
        private readonly SignInManager<Admin> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthenticationService(UserManager<Admin> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<Admin> signInManager
            )
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
           
        }
        // Cette méthode authentifie l'utilisateur en utilisant les informations d'authentification fournies.
        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {

            AuthenticationResponse response = null;
            // La méthode FindByNameAsync() est utilisée pour chercher l'utilisateur par nom d'utilisateur.
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                response = new AuthenticationResponse();
                return response;
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                // La méthode PasswordSignInAsync() est utilisée pour authentifier l'utilisateur en utilisant son nom d'utilisateur et son mot de passe.

                response = new AuthenticationResponse();
                return response;
            }
            // La méthode GenerateToken() est utilisée pour générer un token JWT pour l'utilisateur authentifié.

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
        // Cette méthode génère un token JWT pour l'utilisateur authentifié.

        private async Task<JwtSecurityToken> GenerateToken(Admin user)
        {
            // Une liste de revendications est créée pour le token JWT.
            var authClaims = new List<Claim>
            {

                 new Claim("uid", user.Id),
                 new Claim( ClaimTypes.Name,user.UserName ),
                 new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 new Claim(JwtRegisteredClaimNames.Email, user.Email),
            };

            // Une clé de sécurité et des informations d'identification de signature sont créées pour le token JWT.

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            // Un token JWT est créé avec les informations de configuration fournies.
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
