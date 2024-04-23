using Microsoft.AspNetCore.Mvc;
using PunchService.Model;

namespace PunchService.Controllers;

[ApiController]
[Route("/api/[controller]/{signedDocumentId}")]
public class PunchController : ControllerBase
{
    private readonly PunchRepo _repo;

    public PunchController(PunchRepo punchRepo)
    {
        _repo = punchRepo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Punch>>> GetPuchesForSignedDocument(int signedDocumentId)
    {
        var result = await _repo.GetPunchesForSignedDocumentAsync(signedDocumentId);
        Console.WriteLine($"--> Returning punches for signed document: {signedDocumentId}");
        if (result != null)
        {
            return Ok(result);
        }

        return NotFound();
    }

    [HttpGet("{punchId}", Name = "GetPunchForSignedDocument")]
    public async Task<ActionResult<Punch>> GetPunchForSignedDocument(int signedDocumentId, int punchId)
    {
        var result = await _repo.GetPunchAsync(punchId, signedDocumentId);

        if (result != null)
        {
            Console.WriteLine($"--> Returning punch: {result.Id}");
            return Ok(result);
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<Punch>> CreatePunch(int signedDocumentId, Punch punch)
    {
        if (punch == null)
        {
            return BadRequest("Missing punch data...");
        }
        else if (await _repo.AddPunchAsync(punch, signedDocumentId))
        {
            return CreatedAtRoute(nameof(GetPunchForSignedDocument), punch);
        }
        else
        {
            return StatusCode(500, "Could not create new punch...");
        }
    }

    [HttpPost("{punchId}")]
    public async Task<ActionResult> UpdatePunch(Punch punch, int signedDocumentId, int punchId)
    {
        if(await _repo.UpdatePunchAsync(punch, punchId, signedDocumentId))
        {
            return Ok(punch);
        }
        return BadRequest("Not enough information supplied");
    }

    [HttpDelete("{punchId}")]
    public async Task<ActionResult> DeletePunch(int signedDocumentId, int punchId)
    {
        if(await _repo.DeletePunchAsync(punchId, signedDocumentId))
        {
            return Ok();
        }
        else return NotFound();
    }


}
