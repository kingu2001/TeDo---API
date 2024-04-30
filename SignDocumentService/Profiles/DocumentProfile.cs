using AutoMapper;
using SignDocumentService.Dtos;
using SignDocumentService.Models;

namespace SignDocumentService.Profiles;

public class DocumentProfile : Profile
{
    public DocumentProfile()
    {
        CreateMap<Document, DocumentReadDto>();
        CreateMap<DocumentCreateDto, Document>();
    }
}
