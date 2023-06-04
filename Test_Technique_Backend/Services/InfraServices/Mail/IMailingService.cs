namespace Test_Technique_Backend.Services.InfraServices.Mail
{
    //Cette interface définit une méthode pour envoyer des courriers électroniques
    public interface IMailingService
    {
        Task SendEmailAsync(string mailTo, string subject, string body);

    }
}
