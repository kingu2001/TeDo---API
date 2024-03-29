using System.ComponentModel.DataAnnotations;

namespace TestDocumentService.Models
{
    public class DefinitionAndAbbrevation
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string? Definition { get; set; }
        public string? Abbrevation { get; set; }

        //Navigation properties
        public int TestDocumentId { get; set; }
        public TestDocument? TestDocument { get; set; }
    }
}