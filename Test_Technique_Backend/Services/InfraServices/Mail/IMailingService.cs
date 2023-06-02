namespace Test_Technique_Backend.Services.InfraServices.Mail
{
    public interface IMailingService
    {
        Task SendEmailAsync(string mailTo, string subject, string body);

    }
}
