using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PunchService.Data;
using PunchService.Model;

namespace PunchService;

public class PunchRepo : IPunchRepo
{
    private readonly PunchDbContext _repo;

    public PunchRepo(PunchDbContext punchDbContext)
    {
        _repo = punchDbContext;
    }
    public bool AddPunch(Punch punch, int signedDocumentId)
    {
        var result = _repo.SignedDocuments.FirstOrDefault(s => s.Id == signedDocumentId);
        if (result != null)
        {
            result.Punches.Add(punch);
            return SaveChanges();
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> DeletePunchAsync(int id)
    {
        var result = await GetPunchAsync(id);
        if (result != null)
        {
            _repo.Punches.Remove(result);
            return SaveChanges();
        }
        else
        {
            return false;
        }
    }

    public async Task<Punch> GetPunchAsync(int id)
    {
        var result = await _repo.Punches.FirstOrDefaultAsync(p => p.Id == id);
        return result;
    }

    public async Task<IEnumerable<Punch>> GetPunchListAsync()
    {
        var result = await _repo.Punches.ToListAsync();
        return result;
    }

    public bool SaveChanges()
    {
        return _repo.SaveChanges() >= 0;
    }

    public async Task<bool> UpdatePunch(Punch newPunch, int id)
    {
        if (newPunch != null)
        {
            _repo.Punches.Where(p => p.Id == id)
                         .ExecuteUpdate(setters => setters
                         .SetProperty(p => p.Owner, newPunch.Owner)
                         .SetProperty(p => p.SignedDocument, newPunch.SignedDocument)
                         .SetProperty(p => p.PunchNumber, newPunch.PunchNumber)
                         .SetProperty(p => p.Action, newPunch.Action)
                         .SetProperty(p => p.Description, newPunch.Description));
                         
            return SaveChanges();
        }
        else
        {
            return false;
        }
    }
}
