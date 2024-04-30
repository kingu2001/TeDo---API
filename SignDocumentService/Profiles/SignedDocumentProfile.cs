using AutoMapper;
using SignDocumentService.Dtos;
using SignDocumentService.Models;

namespace SignDocumentService.Profiles;

public class SignedDocumentProfile : Profile
{
    public SignedDocumentProfile()
    {
        CreateMap<SignedDocument, SignedDocumentReadDto>().ReverseMap(); 
        CreateMap<SignedDocument, SignedDocumentCreateDto>(); 
        CreateMap<SignedDocumentCreateDto, SignedDocument>();   
    }
}
