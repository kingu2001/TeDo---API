using DocumentService.Data;
using DocumentService.Models;
using Microsoft.EntityFrameworkCore;

namespace FileService;

public class SignedDocumentRepo : ISignedDocumentRepo
{
    private readonly FileDbContext _fileDbContext;

    public SignedDocumentRepo(FileDbContext fileDbContext)
    {
        _fileDbContext = fileDbContext;
    }
    public Task<bool> DeleteDocumentById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<SignedDocument>> GetAllDocuments()
    {
        var result = await _fileDbContext.SignedDocuments.ToListAsync();
        return result;
    }

    public async Task<SignedDocument> GetDocumentById(int id)
    {
        var result = await _fileDbContext.SignedDocuments.FirstOrDefaultAsync(s => s.Id == id);
        return result;
    }

    public bool SaveChanges()
    {
        return _fileDbContext.SaveChanges() >= 0;
    }

    public bool UpdateDocument(SignedDocument signedDocument, int id)
    {
            //Returns number off affected rows
            var result = _fileDbContext.SignedDocuments
                            .Where(d => d.Id == id)
                            .ExecuteUpdate(setters => setters
                                    .SetProperty(b => b.FileContent, signedDocument.FileContent)
                                    .SetProperty(b => b.FileName, signedDocument.FileName));
            if(result > 0)
            {
                return true;
            }
            {
                return false;
            }
    }

    public bool UploadDocumentToDb(SignedDocument signedDocument)
    {
        _fileDbContext.SignedDocuments.Add(signedDocument);
        return SaveChanges();
    }
}
