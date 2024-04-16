using System.ComponentModel.DataAnnotations;
using DocumentService.Models;

namespace FileService;

public class Stamp
{
    [Key]
    public int Id { get; set; } 
    public byte[] Signature { get; set; }
    public string Comment { get; set; }
    public DateTime Date { get; set; }

    // Navigation propterties
    public SignedDocument SignedDocument { get; set; }
}
