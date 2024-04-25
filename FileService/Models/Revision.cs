using System.ComponentModel.DataAnnotations;

namespace FileService.Models;

public class Revision
{
    [Key]
    public int Id { get; set; }
    public int Number { get; set; }
    public string PageAffected { get; set; }
    public string ChapterAffected { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public int SignedDocumentId { get; set; }
}
