
namespace PunchService.Model;

public class SignedDocument : Document
{
    public string? TestType { get; set; }

    // Navigation propterties
    public List<Punch>? Punches { get; set; }

}