using System.ComponentModel.DataAnnotations;
using TestDocumentService.Models;

namespace TestDocumentService.Dtos.FirmDtos
{
    public class Participant
    {
        [Key]
        [Required]
        public int Id {get; set;}
        [Required]
        public string? Name { get; set; }    
        [Required]
        public Firm? Firm { get; set; }
        [Required]
        public string? Signature { get; set; }
        [Required]
        public DateOnly Date { get; set; }
    }
}