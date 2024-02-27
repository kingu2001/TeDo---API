using System.ComponentModel.DataAnnotations;

namespace TestDocumentService.Dtos
{
    public class PunchReadDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int PunchNumber { get; set; }
        public string? Description { get; set; }
        public string? Owner { get; set; }
        public string? Action { get; set; }
    }
}