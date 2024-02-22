using System.ComponentModel.DataAnnotations;

namespace TestDocumentService.Models
{
    public class Revision
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public string? PageAffected { get; set; }   
        [Required] 
        public string? ChapterAffected { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public DateOnly Date { get; set; }             
    }
}