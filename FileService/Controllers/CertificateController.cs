using FileService.Data.Repositories;
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

        [HttpGet("{id}", Name = "GetCertificateById")]
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

        [HttpGet]
        [Route("/api/Document/GetAllCertificateInformation")]
        public async Task<ActionResult<Certificate>> GetAllCertificateInformation()
        {
            var retrievedCertificates = await _certificateRepo.GetAllCertificates();
            if (retrievedCertificates == null)
            {
                return NotFound("--> The database is empty");
            }
            return Ok(retrievedCertificates);
        }

        

        [HttpPost]
        [Route("/api/Document/UploadCertificateData")]
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

            return CreatedAtRoute(nameof(GetCertficateById), new { id = uploadCertificate.Id }, uploadCertificate);
        }

        //[HttpPost]
        //[Route("/api/Document/UploadFileJson")]
        //public ActionResult<Document> UploadFileJson(Document document)
        //{
        //    if (document == null)
        //    {
        //        return BadRequest("Missing JSON body is empty");
        //    }
        //    var dbSaveResult = _repo.UploadDocumentToDb(document);


        //    if (dbSaveResult)
        //    {
        //        Console.WriteLine($"--> File uploaded succesfully: {document.FileName}");
        //        return CreatedAtRoute(nameof(GetDocumentById), new { id = document.Id }, document);
        //    }
        //    else
        //    {
        //        Console.WriteLine("--> File upload failed... Check repository logs for errors");
        //        return StatusCode(500, "Upload failed... Check server logs for erros");
        //    }
        //}


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
