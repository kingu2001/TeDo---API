using System.Reflection.Metadata;
using AutoMapper;
using FileService.Dtos;
using Document = FileService.Models.Document;

namespace FileService.Profiles;

public class DocumentProfile : Profile
{
    public DocumentProfile()
    {
        CreateMap<Document, DocumentReadDto>();
        CreateMap<DocumentCreateDto, Document>();
        CreateMap<Document, DocumentInfoDto>();
    }
}
