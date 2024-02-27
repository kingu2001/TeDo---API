using System.ComponentModel.DataAnnotations;
using TestDocumentService.Models.Enums;

namespace TestDocumentService.Dtos
{
    public class FirmReadDto
    {
        [Key]
        [Required]
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? FullAddress { get; set; }
        public List<TestType>? TestTypes { get; set; }

    }
}