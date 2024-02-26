using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        public string? Date { get; set; }

        //Navigation props
        [Required]
        public Firm Firm { get; set; }
        [JsonIgnore]
        public List<TestDocument>? TestDocuments { get; set;}
    }
}