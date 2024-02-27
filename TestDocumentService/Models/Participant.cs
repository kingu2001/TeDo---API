using System.ComponentModel.DataAnnotations;

namespace TestDocumentService.Models
{
    public class Participant
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }    
        public string? Signature { get; set; }
        public string? Date { get; set; }         

        //Navigation properties
        public ICollection<TestDocumentParticipant> TestDocumentParticipant { get; set; }
        public ICollection<TestDocument> TestDocuments { get; set; }
        public int FirmId { get; set; }
        public Firm Firm { get; set; }
    }
}