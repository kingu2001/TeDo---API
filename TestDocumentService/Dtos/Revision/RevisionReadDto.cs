using System.ComponentModel.DataAnnotations;

namespace TestDocumentService.Models
{
    public class RevisionReadDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string? PageAffected { get; set; }
        public string? ChapterAffected { get; set; }
        public string? Description { get; set; }
        public string? Date { get; set; }
    }
}