using DocumentService.Models;

namespace FileService;

public interface ISignedDocumentRepo
{
        bool SaveChanges();
        Task<IEnumerable<SignedDocument>> GetAllDocuments();
        Task<SignedDocument> GetDocumentById(int id);
        bool UpdateDocument(SignedDocument signedDocument, int id);
        Task<bool> DeleteDocumentById(int id);
        bool UploadDocumentToDb(SignedDocument signedDocument);
}
