using FileService.Data;
using FileService.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileService.Controllers
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

            // Uncomment bellow line to return as file and not JSON
            //return File(retrivedDocument.FileContent, retrivedDocument.ContentType, retrivedDocument.FileName, true);
            return Ok(retrivedDocument);
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
        [Route("/api/Document/UploadFileFormData")]
        public async Task<ActionResult<Document>> UploadFileFormData()
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

        [HttpPost]
        [Route("/api/Document/UploadFileJson")]
        public ActionResult<Document> UploadFileJson(Document document)
        {
            if(document == null)
            {
                return BadRequest("Missing JSON body is empty"); 
            }
            var dbSaveResult = _repo.UploadDocumentToDb(document);


            if(dbSaveResult)
            {
                Console.WriteLine($"--> File uploaded succesfully: {document.FileName}");
                return CreatedAtRoute(nameof(GetDocumentById), new {id = document.Id}, document);
            }
            else
            {
                Console.WriteLine("--> File upload failed... Check repository logs for errors");
                return StatusCode(500, "Upload failed... Check server logs for erros");
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDocumentById(int id)
        {
            if(await _repo.DeleteDocumentById(id))
            {
                return Ok("--> Document was deleted successfully");
            }

            return NotFound($"--> Document with id {id} was not found");

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
