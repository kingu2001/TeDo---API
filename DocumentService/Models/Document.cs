using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DocumentService.Models;

public class Document
{
    [Key]
    public int Id { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
    [JsonIgnore]
    public byte[] FileContent { get; set; }
}
