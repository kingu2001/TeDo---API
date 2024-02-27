using AutoMapper;
using TestDocumentService.Dtos;
using TestDocumentService.Models;

namespace TestDocumentService.Profiles
{
    public class TestProfile : Profile
    {
        public TestProfile()
        {
            CreateMap<Test, TestReadDto>().ReverseMap();
        }
    }

}