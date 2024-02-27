using AutoMapper;
using TestDocumentService.Dtos;
using TestDocumentService.Models;

namespace TestDocumentService.Profiles
{
    public class DefAndAbbProfile : Profile
    {
        public DefAndAbbProfile()
        {
            CreateMap<DefinitionAndAbbrevation, DefinitionAndAbbrevationReadDto>().ReverseMap();
        }
    }

}