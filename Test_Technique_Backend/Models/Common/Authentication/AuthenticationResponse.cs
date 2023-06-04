namespace Test_Technique_Backend.Models.Common.Authentication
{
    // Cette classe représente la réponse renvoyée par l'API après une opération d'authentification réussie.
    public class AuthenticationResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
      
    }
}
