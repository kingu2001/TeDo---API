using System.ComponentModel.DataAnnotations;

namespace TestDocumentService.Models
{
    public class TestDocumentCreateDto
    {
        [Required]
        public string? Introduction  { get; set; }
        [Required]
        public Dictionary<string, string>? DefinitionAndAbbreviations  { get; set; }
        public string? DocumentSupplied {get; set;}
        [Required]
        public List<Punch>? PunchList { get; set; }
        [Required]
        public List<PlaceOfTesting>? PlacesOfTesting { get; set; }
        [Required]
        public List<Revision>? Revisions { get; set; }
        [Required]
        public List<Test>? Tests { get; set; }
    }
}