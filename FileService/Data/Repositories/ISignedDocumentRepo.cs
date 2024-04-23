using DocumentService.Models;

namespace FileService;

public interface ISignedDocumentRepo
{
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<SignedDocument>> GetAllDocumentsAsync();
        Task<SignedDocument> GetDocumentByIdAsync(int id);
        Task<bool> DeleteDocumentByIdAsync(int id);
        Task<bool> AddSignedDocumentAsync(SignedDocument signedDocument);
}
