using System.ComponentModel.DataAnnotations;

namespace TestDocumentService.Models
{
    public class PlaceOfTesting
    {
        [Key]
        [Required]
        public int Id {get; set;}
        [Required]
        public TestType TestType {get; set;}
        
        //Navigation
        public List<TestDocument> TestDocuments { get; set; }
        [Required]
        public int FimId { get; set; }
        public Firm Firm { get; set; }
    }
}