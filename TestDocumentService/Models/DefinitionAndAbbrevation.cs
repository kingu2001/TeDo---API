using System.ComponentModel.DataAnnotations;
using TestDocumentService.Models;

namespace TestDocumentService;

public class DefinitionAndAbbrevation
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string? Definition { get; set; }
    public string? Abbrevation { get; set; }

    //Navigation properties
    [Required]
    public TestDocument TestDocument { get; set; }
}
