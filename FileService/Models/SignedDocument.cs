namespace FileService.Models;

public class SignedDocument : Document
{

    // Navigation propterties
    public List<Punch>? Punches { get; set; }
    public List<Revision>? Revisions { get; set; }
    public List<Stamp> Stamps { get; set; }

}