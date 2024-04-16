using PunchService.Model;

namespace PunchService;

public interface IPunchRepo
{
    bool SaveChanges();
    Task<Punch> GetPunchAsync(int id);
    Task<IEnumerable<Punch>> GetPunchListAsync();
    bool AddPunch(Punch punch, int signedDocumentId);
    Task<bool> UpdatePunch(Punch newPunch, int id);
    Task<bool> DeletePunchAsync(int id);
}
