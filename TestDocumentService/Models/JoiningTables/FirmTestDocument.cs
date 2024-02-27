using System.ComponentModel.DataAnnotations;

namespace TestDocumentService.Models
{
    public class FirmTestDocument
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        public int FirmId { get; set; }
        public Firm Firm { get; set; }

        public int TestDocumentId { get; set; }
        public TestDocument? TestDocument { get; set; }
    }
}