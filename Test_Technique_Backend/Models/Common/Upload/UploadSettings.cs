using System.ComponentModel.DataAnnotations;

namespace Test_Technique_Backend.Models.Common.Upload
{
    public class UploadSettings
    {
        [Required]
        public string Url { get; set; }
    }
}
