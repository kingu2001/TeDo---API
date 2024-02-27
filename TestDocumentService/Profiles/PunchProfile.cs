using AutoMapper;
using TestDocumentService.Dtos;
using TestDocumentService.Models;

namespace TestDocumentService.Profiles
{
    public class PunchProfile : Profile
    {
        public PunchProfile()
        {
            CreateMap<Punch, PunchReadDto>().ReverseMap();
        }
    }

}