using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using Test_Technique_Backend.Models.Common.Upload;

namespace Test_Technique_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Cette classe est un contrôleur ASP.NET Core pour gérer les requêtes d'upload de fichiers.
    public class UploadController : ControllerBase
    {
     
        private readonly UploadSettings _uploadSettings;
        // Ce constructeur permet l'injection de dépendances de IOptions<UploadSettings>.
        public UploadController( IOptions<UploadSettings> uploadSettings)
        {
            
            _uploadSettings = uploadSettings.Value;
        }

        // Cette annotation spécifie que cette méthode doit être appelée lorsqu'une requête POST est envoyée à l'URL "/api/upload" et désactive la limite de taille de la requête.
        [HttpPost]
        [DisableRequestSizeLimit]
        // Cette méthode gère une requête pour uploader un fichier.
        public async Task<IActionResult> UploadFile()
        {
            if (!Request.Form.Files.Any())
                return BadRequest("No files found in the request");

            if (Request.Form.Files.Count > 1)
                return BadRequest("Cannot upload more than one file at a time");

            if (Request.Form.Files[0].Length <= 0)
                return BadRequest("Invalid file length, seems to be empty");

            try
            {
                
                string uploadsDir = _uploadSettings.Url;
                //Si le dossier d'upload n'existe pas, il est créé.
                if (!Directory.Exists(uploadsDir))
                    Directory.CreateDirectory(uploadsDir);
                // Le fichier est récupéré à partir de la requête.
                IFormFile file = Request.Form.Files[0];
                // Le nom du fichier est extrait des en-têtes de la requête.
                string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                // Le chemin complet du fichier est construit en combinant le dossier d'upload et le nom de fichier.
                string fullPath = Path.Combine(uploadsDir, fileName);
                // La taille du tampon utilisé pour écrire le fichier est définie.
                var buffer = 1024 * 1024;
                // Un flux de fichier est créé pour écrire le fichier.
                using var stream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, buffer, useAsync: false);
                // Le contenu du fichier est copié dans le flux.
                await file.CopyToAsync(stream);
                // Le flux est vidé.
                await stream.FlushAsync();
                // L'emplacement final du fichier est défini.
                string location = fullPath;

                var result = new List<object>();
                result.Add(new
                {
                    message = "Upload successful",
                    url = location
                });


                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Upload failed: " + ex.Message);
            }
        }
    }
}
