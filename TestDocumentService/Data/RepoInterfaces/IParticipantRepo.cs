using TestDocumentService.Models;

namespace TestDocumentService.Data.Interfaces
{
    interface IParticipant
    {
        bool SaveChanges();
        IEnumerable<Participant> GetAllParticipant();
        void CreateFirm(Participant participant);
    }
}