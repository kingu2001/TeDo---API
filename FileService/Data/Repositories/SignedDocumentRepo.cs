using FileService.Models;
using Microsoft.EntityFrameworkCore;

namespace FileService.Data
{
    public class SignedDocumentRepo : ISignedDocumentRepo
    {
        private readonly FileDbContext _fileDbContext;

        public SignedDocumentRepo(FileDbContext fileDbContext)
        {
            _fileDbContext = fileDbContext;
        }
        public async Task<bool> DeleteDocumentByIdAsync(int id)
        {
            var result = await _fileDbContext.SignedDocuments.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }
            _fileDbContext.SignedDocuments.Remove(result);

            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<SignedDocument>> GetAllDocumentsAsync()
        {
            var result = await _fileDbContext.SignedDocuments.ToListAsync();
            return result;
        }

        public async Task<SignedDocument> GetDocumentByIdAsync(int id)
        {
            var result = await _fileDbContext.SignedDocuments.Where(s => s.Id == id)
                                .Include("Stamps")
                                .Include("Revisions")
                                .Include("Punches")
                                .AsSplitQuery()
                                .FirstOrDefaultAsync();
            return result;
        }

        public Task<bool> AddSignedDocumentAsync(SignedDocument signedDocument)
        {
            _fileDbContext.SignedDocuments.Add(signedDocument);
            return SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _fileDbContext.SaveChangesAsync() >= 0;
        }

        public async Task<bool> UpdateSignedDocumentAsync(SignedDocument signedDocument, int signedDocumentId)
        {
            if(signedDocument == null)
            {
                throw new ArgumentNullException(nameof(signedDocument));
            }
            var result = await _fileDbContext.SignedDocuments
                            .Where(s => s.Id == signedDocumentId)
                            .ExecuteUpdateAsync(setters => setters
                                .SetProperty(s => s.Stamps, signedDocument.Stamps)
                                .SetProperty(s => s.Punches, signedDocument.Punches)
                                .SetProperty(s => s.Revisions, signedDocument.Revisions));
            if (result > 0)
                return true;
            else
                return false;
        }
    }
}
