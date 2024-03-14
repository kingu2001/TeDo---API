using System.Net;
using DocumentService.Data;
using DocumentService.Models;
using Microsoft.AspNetCore.Mvc;

namespace DocumentService.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentRepo _repo;

        public DocumentController(IDocumentRepo documentRepo)
        {
            _repo = documentRepo;
        }

        //MISSING IMPLEMENTATION
        [HttpGet]
        public async Task<ActionResult<Document>> GetAllDocuments()
        {
            var documentList = await _repo.GetAllDocuments();
            var document = documentList.FirstOrDefault();

            var respone = new HttpResponseMessage(HttpStatusCode.OK);

        }

        [HttpPost]
        public async Task<ActionResult<Document>> UploadFile()
        {
            if (!Request.HasFormContentType)
            {
                return BadRequest("Expected a form data request");
            }

            var form = await Request.ReadFormAsync();
            var file = form.Files.FirstOrDefault();

            if(file == null)
            {
                return BadRequest("No file uploaded");
            }

            var uploadedFile = new Document
            {
                FileName = file.FileName,
                ContentType = file.ContentType,
                FileContent = await ReadFileContentAsync(file.OpenReadStream())
            };

            _repo.UploadDocumentToDb(uploadedFile);
            
            return Ok(nameof(uploadedFile));
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
