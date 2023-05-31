using Test_Technique_Backend.Models.Common.Authentication;

namespace Test_Technique_Backend.Services.InfraServices.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
    }
}
