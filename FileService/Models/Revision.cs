using System.ComponentModel.DataAnnotations;
using DocumentService.Models;

namespace FileService;

public class Revision
{
    [Key]
    public int Id { get; set; }
    public int Number { get; set; } 
    public string PageAffected { get; set; }
    public string ChapterAffected { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }

    // Navigation propterties
    public SignedDocument SignedDocument { get; set; }

}
