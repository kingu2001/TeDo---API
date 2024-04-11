using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace PunchService;

[ApiController]
[Route("/api/[controller]")]
public class PunchController : ControllerBase
{
    private readonly HttpClient _client;
    private readonly string documentServiceBaseURL;
    private readonly string documentServiceGetIdEndpoint;
    private readonly string documentServiceUploadEndpoint;

    public PunchController(HttpClient httpClient)
    {
        _client = httpClient;
        documentServiceBaseURL = "http://localhost:5297";
        documentServiceGetIdEndpoint = "/api/Document/GetDocumentById";
        documentServiceUploadEndpoint = "/api/Document/UploadFileJson";
    }

    [HttpPatch]
    public async Task<ActionResult<Punch>> CreatePunch(Punch punch, int id)
    {
        // Retrive document for adding punch
       var retrievedDocument = await _client.GetAsync(documentServiceBaseURL + documentServiceGetIdEndpoint);

       if(!retrievedDocument.IsSuccessStatusCode)
       {
            return NotFound($"No document found with supplied id...");
       }
        
        Document document = JsonSerializer.Deserialize<Document>(retrievedDocument.ToString());

        document.PunchList.Add(punch);

        var result = await _client.PostAsJsonAsync(documentServiceBaseURL + documentServiceUploadEndpoint, document);
        if(!result.IsSuccessStatusCode)
        {
            return StatusCode(500, "Could not save entity in database. Dropping supplied punch.\nCheck document logs for errors.");
        }

        return CreatedAtRoute(NotImplemented);
    }

    [HttpGet("{id}", Name = "GetPunchById")]
    public async Task<ActionResult<Punch>> GetPunchById(int id)
    {
        
    }
}
