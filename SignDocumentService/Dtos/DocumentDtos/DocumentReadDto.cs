namespace SignDocumentService.Dtos;

public class DocumentReadDto
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public byte[] FileContent { get; set; }
}
