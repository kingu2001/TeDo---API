using System.ComponentModel.DataAnnotations;

namespace TestDocumentService.Models
{
    public class Test
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? TestProcedure  { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? IATInitials  { get; set; }
        [Required]
        public string? FATInitials  { get; set; }
        [Required]
        public string? SATInitials   { get; set; }
        [Required]
        public string? OATInitials   { get; set; }
    }
}