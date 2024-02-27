using System.ComponentModel.DataAnnotations;

namespace TestDocumentService.Dtos
{
    public class DefinitionAndAbbrevationReadDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string? Definition { get; set; }
        public string? Abbrevation { get; set; }
    }
}