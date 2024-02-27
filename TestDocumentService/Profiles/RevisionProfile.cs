using AutoMapper;
using TestDocumentService.Dtos;
using TestDocumentService.Models;

namespace TestDocumentService.Profiles
{
    public class RevisionProfile : Profile
    {
        public RevisionProfile()
        {
            CreateMap<Revision, RevisionReadDto>().ReverseMap();
        }
    }

}