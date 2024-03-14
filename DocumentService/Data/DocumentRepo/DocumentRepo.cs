using DocumentService.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentService.Data
{
    public class DocumentRepo : IDocumentRepo
    {
        private readonly DocumentDbContext _documentDbContext;

        public DocumentRepo(DocumentDbContext documentDbContext)
        {
            _documentDbContext = documentDbContext;
        }

        public bool SaveChanges()
        {
            return _documentDbContext.SaveChanges() >= 0;
        }

        public Document GetDocumentById(int id)
        {
            var result =_documentDbContext.Documents.FirstOrDefault(d => id == d.Id);
            if(result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }
            return result;
        }

        public void UploadDocumentToDb(Document document)
        {
            _documentDbContext.Add(document);
            SaveChanges();
        }

        public async Task<IEnumerable<Document>> GetAllDocuments()
        {
            var result = await _documentDbContext.Documents.ToListAsync();
            return result;
        }
    }
}
