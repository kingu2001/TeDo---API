using PunchService.Model;

namespace PunchService;

public interface IPunchRepo
{
    bool SaveChanges();
    Punch GetPunch(int punchId, int signedDocumentId);
    IEnumerable<Punch> GetPunchesForSignedDocument(int signedDocumentId);
    bool AddPunch(Punch punch, int signedDocumentId);
    bool UpdatePunch(Punch newPunch, int punchId, int signedDocumentId);
    bool DeletePunchAsync(int punchId, int signedDocumentId);
}
