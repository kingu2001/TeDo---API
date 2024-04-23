using PunchService.Model;

namespace PunchService;

public interface IPunchRepo
{
    Task<bool> SaveChangesAsync();
    Task<Punch> GetPunchAsync(int punchId, int signedDocumentId);
    Task<IEnumerable<Punch>> GetPunchesForSignedDocumentAsync(int signedDocumentId);
    Task<bool> AddPunchAsync(Punch punch, int signedDocumentId);
    Task<bool> UpdatePunchAsync(Punch punch, int punchId, int signedDocumentId);
    Task<bool> DeletePunchAsync(int punchId, int signedDocumentId);
}
