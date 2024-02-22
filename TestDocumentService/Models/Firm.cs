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
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? FullAddress { get; set; }
                 
    }
}