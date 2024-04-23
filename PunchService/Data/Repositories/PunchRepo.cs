using Microsoft.EntityFrameworkCore;
using PunchService.Data;
using PunchService.Model;

namespace PunchService;

public class PunchRepo : IPunchRepo
{
    private readonly PunchDbContext _context;

    public PunchRepo(PunchDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddPunchAsync(Punch punch, int signedDocumentId)
    {
        if (punch == null)
        {
            throw new ArgumentNullException(nameof(punch));
        }
        punch.SignedDocumentId = signedDocumentId;
        _context.Punches.Add(punch);

        return await SaveChangesAsync();
    }

    public async Task<bool> DeletePunchAsync(int punchId, int signedDocumentId)
    {
        var punch = await _context.Punches.FirstOrDefaultAsync(p => p.SignedDocumentId == signedDocumentId && p.Id == punchId);
        _context.Punches.Remove(punch);
        return await SaveChangesAsync();
    }

    public async Task<IEnumerable<Punch>> GetPunchesForSignedDocumentAsync(int signedDocumentId)
    {
        return await _context.Punches
                .Where(p => p.SignedDocumentId == signedDocumentId)
                .OrderBy(p => p.SignedDocument.FileName).ToListAsync();
    }

    public async Task<Punch> GetPunchAsync(int punchId, int signedDocumentId)
    {
        return await _context.Punches
                .Where(p => p.SignedDocumentId == signedDocumentId && p.Id == punchId).FirstOrDefaultAsync();
    }

    public async Task<bool> UpdatePunchAsync(Punch punch, int punchId, int signedDocumentId)
    {
        if (punch == null)
        {
            throw new ArgumentNullException(nameof(punch));
        }

        await _context.Punches.Where(p => p.SignedDocumentId == signedDocumentId && p.Id == punchId)
             .ExecuteUpdateAsync(setters => setters
             .SetProperty(p => p.Owner, punch.Owner)
             .SetProperty(p => p.SignedDocument, punch.SignedDocument)
             .SetProperty(p => p.PunchNumber, punch.PunchNumber)
             .SetProperty(p => p.Action, punch.Action)
             .SetProperty(p => p.Description, punch.Description));

        return await SaveChangesAsync();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() >= 0;
    }
}
