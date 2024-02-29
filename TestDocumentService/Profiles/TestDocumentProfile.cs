using AutoMapper;
using TestDocumentService.Dtos;
using TestDocumentService.Models;

namespace TestDocumentService.Profiles
{
    public class TestDocumentProfile : Profile
    {
        public TestDocumentProfile()
        {
            CreateMap<TestDocument, TestDocumentReadDto>()
            .ForMember(dest => dest.Firms, opt => opt.MapFrom(src => src.Firms))
            .ForMember(dest => dest.Participants, opt => opt.MapFrom(src => src.Participants))
            .ForMember(dest => dest.Revisions, opt => opt.MapFrom(src => src.Revisions))
            .ForMember(dest => dest.Punches, opt => opt.MapFrom(src => src.Punches))
            .ForMember(dest => dest.Tests, opt => opt.MapFrom(src => src.Tests))
            .ForMember(dest => dest.DefinitionAndAbbrevations, opt => opt.MapFrom(src => src.DefinitionAndAbbrevations));
        }
    }

}