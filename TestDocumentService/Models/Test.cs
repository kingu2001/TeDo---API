using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TestDocumentService.Models
{
    public class Test
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

        //Navigation properties
        public int? TestDocumentId { get; set; }
        public TestDocument? TestDocument { get; set; }
        public ICollection<Punch>? Punches { get; set; }
    }
}