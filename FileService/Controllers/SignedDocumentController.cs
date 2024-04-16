using Microsoft.AspNetCore.Mvc;

namespace FileService;

[Route("api/[controller]")]
[ApiController]
public class SignedDocumentController : ControllerBase
{
    private readonly SignedDocumentRepo _repo;

    public SignedDocumentController(SignedDocumentRepo signedDocumentRepo)
    {
        _repo = signedDocumentRepo;
    }
    
}
