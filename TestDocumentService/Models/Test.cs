using System.ComponentModel.DataAnnotations;

namespace TestDocumentService.Models
{
    public class Test
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? TestProcedure  { get; set; }
        public string? Description { get; set; }
        public string? IATInitials  { get; set; }
        public string? FATInitials  { get; set; }
        public string? SATInitials   { get; set; }
        public string? OATInitials   { get; set; }

        //Navigation properties
        public int? PuchId { get; set; }
        public Punch? Punch { get; set; }

        [Required]
        public int TestDocumentId { get; set; }
        public List<TestDocument> TestDocument { get; set; }
    }
}