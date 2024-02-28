using System.ComponentModel.DataAnnotations;

namespace TestDocumentService.Models
{
    public class Punch
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int PunchNumber { get; set; }
        public string? Description { get; set; }
        public string? Owner { get; set; }
        public string? Action { get; set; }

        //Navigation properties
        public int TestId { get; set; }
        public Test? Test { get; set; }

        public int TestDocumentId { get; set; }
        public TestDocument TestDocument { get; set; }
    }
}