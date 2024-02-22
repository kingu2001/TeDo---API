using System.ComponentModel.DataAnnotations;

namespace TestDocumentService.Models
{
    public class TestDocumentReadDto
    {
        public int Id {get; set;}
        public string? Introduction  { get; set; }
        public Dictionary<string, string>? DefinitionAndAbbreviations  { get; set; }
        public string? DocumentSupplied {get; set;}
        public List<Punch>? PunchList { get; set; }
        public List<PlaceOfTesting>? PlacesOfTesting { get; set; }
        public List<Revision>? Revisions { get; set; }
        public List<Test>? Tests { get; set; }
    }
}