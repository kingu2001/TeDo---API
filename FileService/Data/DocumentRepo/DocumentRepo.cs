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

        public async Task<Document> GetDocumentById(int id)
        {
            var result = await _documentDbContext.Documents.FirstOrDefaultAsync(d => id == d.Id);
            return result;
        }

        public void UploadDocumentToDb(Document document)
        {
            _documentDbContext.Add(document);
            SaveChanges();
        }

        public async Task<IEnumerable<Document>> GetAllDocuments()
        {
            var result =  await _documentDbContext.Documents.ToListAsync();
            return result;
        }

        public bool UpdateDocument(Document document, int id)
        {
            //Returns number off affected rows
            var result = _documentDbContext.Documents
                            .Where(d => d.Id == id)
                            .ExecuteUpdate(setters => setters
                                    .SetProperty(b => b.FileContent, document.FileContent)
                                    .SetProperty(b => b.FileName, document.FileName));
            if(result > 0)
            {
                return true;
            }
            {
                return false;
            }
        }

        public async Task<bool> DeleteDocumentById(int id)
        {
            var foundDocument = await GetDocumentById(id);

            if(foundDocument != null)
            {
                _documentDbContext.Documents.Remove(foundDocument);
                SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
