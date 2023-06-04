namespace Test_Technique_Backend.Models.Common.Authentication
{
    // Cette classe représente les informations nécessaires pour effectuer une demande d'authentification dans l'application.
    public class AuthenticationRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
