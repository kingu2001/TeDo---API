using FileService.Data;
using FileService.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileService.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly ICertificateRepo _certificateRepo;

        public CertificateController(ICertificateRepo certificateRepo)
        {
            _certificateRepo = certificateRepo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCertficateById(int id)
        {
            var retrievedCertificate = await _certificateRepo.GetCertficateById(id);
            if (retrievedCertificate == null)
            {
                return NotFound($"--> No entry with the supplied id exists");
            }
            Console.WriteLine($"--> Returning Certificate: {retrievedCertificate.CertificateOwner}");

            // Uncomment bellow line to return as file and not JSON
            //return File(retrivedDocument.FileContent, retrivedDocument.ContentType, retrivedDocument.FileName, true);
            return Ok(retrievedCertificate);
        }

        

        [HttpPost]
        public async Task<ActionResult<Certificate>> UploadCertificateData()
        {
            if (!Request.HasFormContentType)
            {
                return BadRequest("Expected a form data request");
            }

            var form = await Request.ReadFormAsync();
            var file = form.Files.FirstOrDefault();

            if (file == null)
            {
                return BadRequest("No file uploaded");
            }


            var uploadCertificate = new Certificate
            {
                CertificateOwner = file.FileName,
                CertificateData = await ReadFileContentAsync(file.OpenReadStream()),
            };

            _certificateRepo.UploadCertificateToDb(uploadCertificate);

            Console.WriteLine($"--> File uploaded succesfully: {uploadCertificate.CertificateOwner}");

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCertificateById(int id)
        {
            if (await _certificateRepo.DeleteCertificateById(id))
            {
                return Ok("--> Certificate was deleted successfully");
            }

            return NotFound($"--> Certificate with id {id} was not found");

        }
        private async Task<byte[]> ReadFileContentAsync(Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
