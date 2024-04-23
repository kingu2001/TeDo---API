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
        var result = await _fileDbContext.SignedDocuments.FirstOrDefaultAsync(s => s.Id == id);
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
}
