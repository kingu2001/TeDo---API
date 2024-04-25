
using Microsoft.AspNetCore.Mvc;
using FileService.Models;
using FileService.Data;

namespace FileService.Controllers;

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
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound("No signed documents exists");
    }

    [HttpGet("{id}", Name = "GetSignedDocumentById")]
    public async Task<ActionResult<SignedDocument>> GetSignedDocumentById(int id)
    {
        var result = await _repo.GetDocumentByIdAsync(id);
        if (result != null)
        {
            return Ok(result);

        }
        else return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<SignedDocument>> CreateSignedDocument(SignedDocument signedDocument)
    {
        var result = await _repo.AddSignedDocumentAsync(signedDocument);
        if (result)
        {
            return CreatedAtRoute(nameof(GetSignedDocumentById), result);
        }
        else return StatusCode(500, "Creation failed");
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<SignedDocument>> UpdateSignedDocument(SignedDocument signedDocument, int id)
    {
        var result = await _repo.UpdateSignedDocumentAsync(signedDocument, id);
        if (result)
        {
            return StatusCode(204, signedDocument);
        }
        else return StatusCode(500);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSignedDocument(int id)
    {
        var result = await _repo.DeleteDocumentByIdAsync(id);
        if (result)
        {
            var updatedSignedDocument = await _repo.GetDocumentByIdAsync(id);
            return Ok(updatedSignedDocument);
        }
        else return NotFound();
    }
}
