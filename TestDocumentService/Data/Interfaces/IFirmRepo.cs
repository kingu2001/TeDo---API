using TestDocumentService.Models;

namespace TestDocumentService.Data.Interfaces
{
    interface IFirmRepo
    {
        bool SaveChanges();
        IEnumerable<Firm> GetAllFirms();
        void CreateFirm(Firm firm);
    }
}