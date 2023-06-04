using System.ComponentModel.DataAnnotations;

namespace Test_Technique_Backend.Models.Common.Upload
{
    // Cette classe contient la configuration nécessaire pour télécharger des fichiers dans l'application.
    public class UploadSettings
    {
        [Required]
        public string Url { get; set; }
    }
}
