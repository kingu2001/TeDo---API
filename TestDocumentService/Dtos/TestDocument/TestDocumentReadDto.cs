using System.ComponentModel.DataAnnotations;
using TestDocumentService.Models;

namespace TestDocumentService.Dtos
{
    public class TestDocumentReadDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Introduction { get; set; }
        public string? DocumentSupplied { get; set; }

        //Navigation Properties
        public ICollection<PunchReadDto> Punches{ get; set; }
        public ICollection<ParticipantReadDto>? Participants { get; set; }
        public ICollection<DefinitionAndAbbrevationReadDto>? DefinitionAndAbbrevations { get; set; }
        public ICollection<RevisionReadDto>? Revisions { get; set; }
        public ICollection<TestReadDto> Tests { get; set; }
        public ICollection<FirmReadDto> Firms { get; set; } 
    }
}