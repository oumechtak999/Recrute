namespace Test_Technique_Backend.Models.Common.Mail
{
    // Cette classe contient la configuration nécessaire  de l'expéditeur pour envoyer des e-mails dans l'application.
    public class MailSettings
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
