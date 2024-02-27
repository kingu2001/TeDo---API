using System.ComponentModel.DataAnnotations;

namespace TestDocumentService.Dtos
{
    public class TestReadDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string? TestProcedure { get; set; }
        public string? Description { get; set; }
        public string? IATInitials { get; set; }
        public string? FATInitials { get; set; }
        public string? SATInitials { get; set; }
        public string? OATInitials { get; set; }

    }
}