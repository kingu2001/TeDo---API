using DocumentService.Models;

namespace DocumentService.Data
{
    public interface IDocumentRepo
    {
        bool SaveChanges();
        Task<IEnumerable<Document>> GetAllDocuments();
        Task<Document> GetDocumentById(int id);
        bool UpdateDocument(Document document, int id);
        Task<bool> DeleteDocumentById(int id);
        void UploadDocumentToDb(Document document);

    }
}


