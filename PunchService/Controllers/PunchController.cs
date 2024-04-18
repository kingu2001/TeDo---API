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
    public ActionResult<IEnumerable<Punch>> GetPuchesForSignedDocument(int signedDocumentId)
    {
        var result = _repo.GetPunchesForSignedDocument(signedDocumentId);
        Console.WriteLine($"--> Returning punches for signed document: {signedDocumentId}");
        if(result != null)
        {
            return Ok(result);
        }

        return NotFound();
    }
    

  
}
