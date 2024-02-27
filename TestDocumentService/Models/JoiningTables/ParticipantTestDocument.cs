using System.ComponentModel.DataAnnotations;

namespace TestDocumentService.Models
{
    public class TestDocumentParticipant
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int TestDocumentId { get; set; }
        public TestDocument? TestDocument { get; set; } // Make TestDocument nullable

        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }
    }

}