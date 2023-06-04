using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_Technique_Backend.Models.Common.Authentication;
using Test_Technique_Backend.Services.InfraServices.Authentication;

namespace Test_Technique_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Cette classe est un contrôleur ASP.NET Core pour gérer les requêtes d'authentification.

    public class AccountController : ControllerBase
    {
        // Cette propriété privée contient une référence à l'interface IAuthenticationService, qui est utilisée pour effectuer les opérations d'authentification.
        private readonly IAuthenticationService _authenticationService;
        // Ce constructeur permet l'injection de dépendances de IAuthenticationService.
        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        // Cette annotation spécifie que cette méthode doit être appelée lorsqu'une requête POST
        [HttpPost("authenticate")]
        // Cette méthode gère une requête d'authentification.
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            var result = await _authenticationService.AuthenticateAsync(request);

            return Ok(result);
        }
    }
}
