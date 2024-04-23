using DocumentService.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileService;

[Route("api/[controller]")]
[ApiController]
public class SignedDocumentController : ControllerBase
{
    private readonly ISignedDocumentRepo _repo;

    public SignedDocumentController(ISignedDocumentRepo signedDocumentRepo)
    {
        _repo = signedDocumentRepo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SignedDocument>>> GetSignedDocuments()
    {
        var result = await _repo.GetAllDocumentsAsync();
        if(result != null)
        {
            return Ok(result);
        }
        return NotFound("No signed documents exists");
    }

    [HttpGet("{id}", Name = "GetSignedDocumentById")]
    public async Task<ActionResult<SignedDocument>> GetSignedDocumentById(int id)
    {
        var result = await _repo.GetDocumentByIdAsync(id);
        if(result != null)
        {
            return CreatedAtRoute(nameof(GetSignedDocumentById), result);
        }
        else return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<SignedDocument>> CreateSignedDocument(SignedDocument signedDocument)
    {
        Console.WriteLine("--> Create Signed Document endpoint hit");
        var result = await _repo.AddSignedDocumentAsync(signedDocument);
        if(result)
        {
            return Ok(signedDocument);
        }
        else return StatusCode(500, "Creation failed");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSignedDocument(int id)
    {
        var result = await _repo.DeleteDocumentByIdAsync(id);
        if(result)
        {
            var updatedSignedDocument = await _repo.GetDocumentByIdAsync(id);
            return Ok(updatedSignedDocument);
        }
        else return NotFound();
    }
}
