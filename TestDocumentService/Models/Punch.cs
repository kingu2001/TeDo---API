using System.ComponentModel.DataAnnotations;

namespace TestDocumentService.Models
{
    public class Punch
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int PunchNumber { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Owner { get; set; }
        [Required]
        public string? Action { get; set; }
        
        //Navigation properties
        [Required]
        public int TestId {get; set;}
        public TestDocument? TestDocument { get; set; }

        [Required]
        public int TestDocumentId { get; set; }
        public Test? Test { get; set; }
    }
}