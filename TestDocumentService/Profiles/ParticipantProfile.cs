using AutoMapper;
using TestDocumentService.Dtos;
using TestDocumentService.Models;

namespace TestDocumentService.Profiles
{
    public class ParticipantProfile : Profile
    {
        public ParticipantProfile()
        {
            CreateMap<Participant, ParticipantReadDto>().ReverseMap();
        }
    }

}