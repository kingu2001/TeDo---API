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
        [HttpGet("{id}", Name = "GetDocumentById")]
        public async Task<IActionResult> GetDocumentById(int id)
        {
            var retrivedDocument = await _repo.GetDocumentById(id);
            if(retrivedDocument == null)
            {
                return NotFound($"--> No entry with the supplied id exists");
            }
            Console.WriteLine($"--> Returning File: {retrivedDocument.FileName}");
            return File(retrivedDocument.FileContent, retrivedDocument.ContentType, retrivedDocument.FileName);
        }

        [HttpGet]
        [Route("/api/Document/GetAllDocumentInformation")]
        public async Task<ActionResult<Document>> GetAllDocumentInformation()
        {
            var retrivedDocuments = await _repo.GetAllDocuments();
            if(retrivedDocuments == null)
            {
                return NotFound("--> The database is empty");
            }
            return Ok(retrivedDocuments);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<Document>> UpdateDocumentById(int id)
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

            var updatedDocument = new Document
            {
                FileName = file.FileName,
                ContentType = file.ContentType,
                FileContent = await ReadFileContentAsync(file.OpenReadStream())
            };

            var result = _repo.UpdateDocument(updatedDocument, id);
            if(!result)
            {
                Console.WriteLine("--> Nothing to update");
                return NotFound("--> Nothing to update");
            }
            
            Console.WriteLine($"--> Document updated successfully: {updatedDocument.FileName}");
            return Ok($"Document updated successfully: {updatedDocument.FileName}");
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

            var uploadFile = new Document
            {
                FileName = file.FileName,
                ContentType = file.ContentType,
                FileContent = await ReadFileContentAsync(file.OpenReadStream())
            };

            _repo.UploadDocumentToDb(uploadFile);
            
            Console.WriteLine($"--> File uploaded succesfully: {uploadFile.FileName}");

            return CreatedAtRoute(nameof(GetDocumentById), new {id = uploadFile.Id}, uploadFile);
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
