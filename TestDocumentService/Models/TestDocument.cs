using System.ComponentModel.DataAnnotations;

namespace TestDocumentService.Models
{
    public class TestDocument
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Introduction { get; set; }
        public string? DocumentSupplied { get; set; }

        //Navigation Properties
        public ICollection<Punch> Punches { get; set; }
        public ICollection<TestDocumentParticipant>? TestDocumentParticipants { get; set; }
        public ICollection<Participant>? Participants { get; set; }
        public ICollection<DefinitionAndAbbrevation>? DefinitionAndAbbrevations { get; set; }
        public ICollection<Revision>? Revisions { get; set; }
        public ICollection<Test> Tests { get; set; }
        public ICollection<FirmTestDocument> FirmTestDocuments { get; set; } 
        public ICollection<Firm> Firms { get; set; } 
    }
}   