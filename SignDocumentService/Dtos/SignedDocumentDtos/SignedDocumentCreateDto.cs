using SignDocumentService.Models;

namespace SignDocumentService.Dtos;

public class SignedDocumentCreateDto : DocumentCreateDto
{
    public List<Punch>? Punches { get; set; }
    public List<Revision>? Revisions { get; set; }
    public List<Stamp> Stamps { get; set; }
}
