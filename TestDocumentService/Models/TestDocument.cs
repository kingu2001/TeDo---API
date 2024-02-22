using System.ComponentModel.DataAnnotations;

namespace TestDocumentService.Models
{
    public class TestDocument
    {
        [Key]
        [Required]
        public int Id {get; set;}
        [Required]
        public string? Introduction  { get; set; }
        [Required]
        public Dictionary<string, string>? DefinitionAndAbbreviations  { get; set; }
        [Required]
        public string? DocumentSupplied {get; set;}
        [Required]
        public List<Punch>? PunchList { get; set; }
        [Required]
        public List<PlaceOfTesting>? PlacesOfTesting { get; set; }
    }
}