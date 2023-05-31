using Microsoft.Extensions.Options;
using System.Net.Mail;
using Test_Technique_Backend.Models.Common.Mail;

namespace Test_Technique_Backend.Services.InfraServices.Mail
{
    public class MailingService
    : IMailingService
    {
        private readonly MailSettings _mailSettings;

        public MailingService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(string mailTo, string subject, string body, string path)
        {


            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(_mailSettings.Host);
            mail.From = new MailAddress(_mailSettings.Email);
            mail.To.Add(mailTo);
            mail.Subject = subject;
            mail.Body = body;

            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(path);
            mail.Attachments.Add(attachment);

            SmtpServer.Port = _mailSettings.Port;
            SmtpServer.Credentials = new System.Net.NetworkCredential(_mailSettings.Email, _mailSettings.Password);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }
    }
}
