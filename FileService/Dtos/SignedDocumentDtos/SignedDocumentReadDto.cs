using FileService.Models;

namespace FileService.Dtos;

public class SignedDocumentReadDto : DocumentReadDto
{
    public List<Punch>? Punches { get; set; }
    public List<Revision>? Revisions { get; set; }
    public List<Stamp> Stamps { get; set; }
}
