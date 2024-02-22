using System.ComponentModel.DataAnnotations;

namespace TestDocumentService.Models
{
     public class Participant
    {
        [Key]
        [Required]
        public int Id {get; set;}
        [Required]
        public string? Name { get; set; }    
        [Required]
        public string? Signature { get; set; }
        [Required]
        public DateOnly Date { get; set; }

        //Navigation props
        [Required]
        public Firm? Firm { get; set; }
    }
}