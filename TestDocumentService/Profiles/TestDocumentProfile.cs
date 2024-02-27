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
            .ForMember(dest => dest.FirmDtos, opt => opt.MapFrom(src => src.Firms))
            .ForMember(dest => dest.ParticipantDtos, opt => opt.MapFrom(src => src.Participants))
            .ForMember(dest => dest.RevisionDtos, opt => opt.MapFrom(src => src.Revisions))
            .ForMember(dest => dest.PunchDtos, opt => opt.MapFrom(src => src.Punches))
            .ForMember(dest => dest.TestDtos, opt => opt.MapFrom(src => src.Tests))
            .ForMember(dest => dest.DefinitionAndAbbrevationDtos, opt => opt.MapFrom(src => src.DefinitionAndAbbrevations));
        }
    }

}