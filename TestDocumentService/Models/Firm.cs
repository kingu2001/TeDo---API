using System.ComponentModel.DataAnnotations;

namespace TestDocumentService.Models
{
    public class Firm
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

        //Navigation properties
        public ICollection<Participant>? Participants { get; set; }
        public ICollection<FirmTestDocument>? FirmTestDocuments { get; set; }
        public ICollection<TestDocument>? TestDocuments { get; set; }
    }
}