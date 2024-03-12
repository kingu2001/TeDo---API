using System.ComponentModel.DataAnnotations;
using TestDocumentService.Models;

namespace TestDocumentService.Dtos
{
    public class ParticipantReadDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }    
        public string? Signature { get; set; }
        public string? Date { get; set; }
    }
}