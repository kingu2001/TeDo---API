using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestDocumentService.Models
{
    public class TestDocument
    {
        [Key]
        [Required]
        public int Id {get; set;}
        [Required]
        public Participant? Participant { get; set; }
        [Required]
        public string? Introduction  { get; set; }
        [Required]
        [NotMapped]
        public Dictionary<string, string>? DefinitionAndAbbreviations  { get; set; }
        [Required]
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