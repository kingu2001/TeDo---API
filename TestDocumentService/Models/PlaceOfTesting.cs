using System.ComponentModel.DataAnnotations;

namespace TestDocumentService.Models
{
    public class PlaceOfTesting
    {
        [Key]
        [Required]
        public int Id {get; set;}
        [Required]
        public Firm? Firm { get; set; }
        [Required]
        public TestType TestType {get; set;}
        [Required]
        public TestDocument? TestDocument { get; set; }
    }
}