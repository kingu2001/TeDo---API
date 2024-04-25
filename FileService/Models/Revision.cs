using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
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
    public int SignedDocumentId { get; set; }

    // Navigation propterties
    [JsonIgnore]
    public SignedDocument SignedDocument { get; set; }

}
