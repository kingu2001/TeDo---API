using AutoMapper;
using TestDocumentService.Dtos;
using TestDocumentService.Models;

namespace TestDocumentService.Profiles
{
    public class FirmProfile : Profile
    {
        public FirmProfile()
        {
            CreateMap<Firm, FirmReadDto>().ReverseMap();
        }
    }

}