using System.ComponentModel.DataAnnotations;
using FileService.Models;

namespace FileService.Dtos;

public class SignedDocumentCreateDto : DocumentCreateDto
{
    public List<Punch>? Punches { get; set; }
    public List<Revision>? Revisions { get; set; }
    [Required]
    public List<Stamp> Stamps { get; set; }
}
