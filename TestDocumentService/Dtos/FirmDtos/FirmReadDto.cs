using System.ComponentModel.DataAnnotations;

namespace TestDocumentService.Dtos.FirmDtos
{
    public class FirmReadDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? FullAddress { get; set; }
    }
}