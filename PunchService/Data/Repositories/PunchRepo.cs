using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

    public bool AddPunch(Punch punch, int signedDocumentId)
    {
        if (punch == null)
        {
            throw new ArgumentNullException(nameof(punch));
        }
        punch.SignedDocumentId = signedDocumentId;
        _context.Punches.Add(punch);

        return SaveChanges();
    }

    public bool DeletePunchAsync(int punchId, int signedDocumentId)
    {
        var punch = _context.Punches.FirstOrDefault(p => p.SignedDocumentId == signedDocumentId && p.Id == punchId);
        if (punch != null)
        {
            _context.Punches.Remove(punch);
            return SaveChanges();
        }
        return false;
    }

    public IEnumerable<Punch> GetPunchesForSignedDocument(int signedDocumentId)
    {
        return _context.Punches
                .Where(p => p.SignedDocumentId == signedDocumentId)
                .OrderBy(p => p.SignedDocument.FileName);
    }

    public Punch GetPunch(int punchId, int signedDocumentId)
    {
        return _context.Punches
                .Where(p => p.SignedDocumentId == signedDocumentId && p.Id == punchId).FirstOrDefault();
    }

    public bool UpdatePunch(Punch newPunch, int punchId, int signedDocumentId)
    {
        if (newPunch != null)
        {
            _context.Punches.Where(p => p.SignedDocumentId == signedDocumentId && p.Id == punchId)
                 .ExecuteUpdate(setters => setters
                 .SetProperty(p => p.Owner, newPunch.Owner)
                 .SetProperty(p => p.SignedDocument, newPunch.SignedDocument)
                 .SetProperty(p => p.PunchNumber, newPunch.PunchNumber)
                 .SetProperty(p => p.Action, newPunch.Action)
                 .SetProperty(p => p.Description, newPunch.Description));

            return SaveChanges();
        }
        return false;
    }

    public bool SaveChanges()
    {
        return _context.SaveChanges() >= 0;
    }
}
