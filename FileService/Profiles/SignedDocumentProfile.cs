using AutoMapper;
using FileService.Dtos;
using FileService.Models;

namespace FileService.Profiles;

public class SignedDocumentProfile : Profile
{
    public SignedDocumentProfile()
    {
        CreateMap<SignedDocument, SignedDocumentReadDto>();   
        CreateMap<SignedDocumentCreateDto, SignedDocument>();   
    }
}
