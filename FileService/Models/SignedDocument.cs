using FileService;

namespace DocumentService.Models;

public class SignedDocument : Document
{
    public List<string> Signess { get; set; }
    public string? TestType { get; set; }


    // Navigation propterties
    public List<Punch>? MyProperty { get; set; }
    public List<Revision>? Revisions { get; set; }
    public List<Stamp> Stamps { get; set; }

}