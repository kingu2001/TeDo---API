using System.ComponentModel.DataAnnotations;

namespace TestDocumentService.Dtos
{
    public class FirmReadDto
    {
        [Key]
        [Required]
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? FullAddress { get; set; }
        public bool SAT { get; set; }
        public bool IAT { get; set; }
        public bool OAT { get; set; }
        public bool FAT { get; set; }
    }
}