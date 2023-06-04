namespace Test_Technique_Backend.Models.Common.Authentication
{
    // Cette classe contient la configuration nécessaire pour générer et valider les jetons d'authentification JWT dans l'application.
    public class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double DurationInMinutes { get; set; }
    }
}
