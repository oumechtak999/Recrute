using System.ComponentModel.DataAnnotations;

namespace Test_Technique_Backend.Models.Common.Mail
{
    // Cette classe représente les informations nécessaires du destinataire pour envoyer un e-mail dans l'application.
    public class MailRequestDto
    {
        [Required]
        public string ToEmail { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
       
    }
}
