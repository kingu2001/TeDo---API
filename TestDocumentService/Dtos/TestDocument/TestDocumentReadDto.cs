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
        public ICollection<PunchReadDto> PunchDtos{ get; set; }
        public ICollection<ParticipantReadDto>? ParticipantDtos { get; set; }
        public ICollection<DefinitionAndAbbrevationReadDto>? DefinitionAndAbbrevationDtos { get; set; }
        public ICollection<RevisionReadDto>? RevisionDtos { get; set; }
        public ICollection<TestReadDto> TestDtos { get; set; }
        public ICollection<FirmReadDto> FirmDtos { get; set; } 
    }
}