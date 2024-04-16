using DocumentService.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentService.Data
{
    public class DocumentRepo : IDocumentRepo
    {
        private readonly FileDbContext _fileDbContext;

        public DocumentRepo(FileDbContext documentDbContext)
        {
            _fileDbContext = documentDbContext;
        }

        public bool SaveChanges()
        {
            return _fileDbContext.SaveChanges() >= 0;
        }

        public async Task<Document> GetDocumentById(int id)
        {
            var result = await _fileDbContext.Documents.FirstOrDefaultAsync(d => id == d.Id);
            return result;
        }

        public void UploadDocumentToDb(Document document)
        {
            _fileDbContext.Add(document);
            SaveChanges();
        }

        public async Task<IEnumerable<Document>> GetAllDocuments()
        {
            var result =  await _fileDbContext.Documents.ToListAsync();
            return result;
        }

        public bool UpdateDocument(Document document, int id)
        {
            //Returns number off affected rows
            var result = _fileDbContext.Documents
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
                _fileDbContext.Documents.Remove(foundDocument);
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
