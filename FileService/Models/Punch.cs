using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using DocumentService.Models;

namespace FileService;

public class Punch
{
    [Key]
    public int Id { get; set; }
    public string Test { get; set; }
    public int PunchNumber { get; set; }
    public string  Description { get; set; }
    public string Owner { get; set; }
    public string Action { get; set; }
    public int SignedDocumentId { get; set; }

    // Navigation propterties
    [JsonIgnore]
    public SignedDocument SignedDocument { get; set; }
}
