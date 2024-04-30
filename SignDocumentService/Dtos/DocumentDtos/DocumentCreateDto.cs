using System.ComponentModel.DataAnnotations;

namespace SignDocumentService.Dtos;

public class DocumentCreateDto
{
    [Required]
    public string FileName { get; set; }
    [Required]
    public string ContentType { get; set; }
    [Required]
    public byte[] FileContent { get; set; }
}
