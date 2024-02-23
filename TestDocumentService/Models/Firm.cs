using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace TestDocumentService.Models
{
    public class Firm
    {
        //Når vi får fat i deres firma API, så lav en microservice til denne klasse!
        [Key]
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FullAddress { get; set; }
        
        
        //Navigation props
        public int? PlaceOfTestingId { get; set; }
        public PlaceOfTesting? PlaceOfTesting { get; set; } 
        public List<Participant>? Participants { get; set; }  
    }
}