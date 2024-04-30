using System.ComponentModel.DataAnnotations;

namespace FileService.Dtos;

public class DocumentCreateDto
{
    [Required]
    public string FileName { get; set; }
    [Required]
    public string ContentType { get; set; }
    [Required]
    public byte[] FileContent { get; set; }
}
