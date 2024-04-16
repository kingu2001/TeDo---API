using FileService;

namespace DocumentService.Models;

public class SignedDocument : Document
{
    public List<string> Signess { get; set; }
    public string? TestType { get; set; }


    // Navigation propterties
    public List<Punch>? MyProperty { get; set; }

}