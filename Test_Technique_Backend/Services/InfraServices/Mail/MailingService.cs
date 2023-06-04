using Microsoft.Extensions.Options;
using System.Net.Mail;
using Test_Technique_Backend.Models.Common.Mail;

namespace Test_Technique_Backend.Services.InfraServices.Mail
{
    public class MailingService
    : IMailingService
    {
        private readonly MailSettings _mailSettings;
        // Ce constructeur prend en paramètre une instance de IOptions<MailSettings> pour récupérer la configuration de l'application.
        public MailingService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        // Cette méthode envoie un courrier électronique en utilisant les paramètres de configuration de l'application.
        public async Task SendEmailAsync(string mailTo, string subject, string body)
        {

            // Une nouvelle instance de MailMessage est créée.
            MailMessage mail = new MailMessage();
            // Une nouvelle instance de SmtpClient est créée avec le paramètre de configuration de l'hôte.
            SmtpClient SmtpServer = new SmtpClient(_mailSettings.Host);
            // L'adresse email de l'expéditeur est initialisée avec le paramètre de configuration de l'adresse email.
            mail.From = new MailAddress(_mailSettings.Email);
            // L'adresse email du destinataire est ajoutée à la liste des destinataires.
            mail.To.Add(mailTo);
            // Le sujet du courrier électronique est initialisé avec le paramètre de sujet.
            mail.Subject = subject;
            // Le corps du courrier électronique est initialisé avec le paramètre de corps.
            mail.Body = body;

            // Le port SMTP est initialisé avec le paramètre de configuration du port.

            SmtpServer.Port = _mailSettings.Port;
            // Les informations d'identification SMTP sont initialisées avec les paramètres de configuration de l'adresse email et du mot de passe.
            SmtpServer.Credentials = new System.Net.NetworkCredential(_mailSettings.Email, _mailSettings.Password);
            // La connexion SMTP est configurée pour utiliser SSL.
            SmtpServer.EnableSsl = true;
            // Envoyer le courrier électronique .
            SmtpServer.Send(mail);

        }
    }
}
