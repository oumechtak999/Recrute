using Test_Technique_Backend.Models.Common.Authentication;

namespace Test_Technique_Backend.Services.InfraServices.Authentication
{
    // Cette interface définit une méthode pour l'authentification.
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
    }
}
