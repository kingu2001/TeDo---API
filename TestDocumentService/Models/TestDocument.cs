using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestDocumentService.Models
{
    public class TestDocument
    {
        [Key]
        [Required]
        public int Id {get; set;}
        public string? Name { get; set; }
        public string? Introduction  { get; set; }
        public string? DocumentSupplied {get; set;}
        
        //Navigation propeties
        [Required]
        public List<Test> Tests { get; set;}

        public List<Punch>? PunchList { get; set; }

        [Required]
        public List<Participant> Participants { get; set; }

        public List<Revision>? Revisions {get; set;}

        [Required]
        public List<PlaceOfTesting>? PlaceOfTestings { get; set; }
        
        public List<DefinitionAndAbbrevation>? DefinitionAndAbbrevation { get; set; }
    }
}