using TestDocumentService.Data.Context;
using TestDocumentService.Data.Interfaces;
using TestDocumentService.Models;

namespace TestDocumentService.Data.Repositorys
{
    public class FirmRepo : IFirmRepo
    {
        private readonly AppDbContext _context;
        public FirmRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateFirm(Firm firm)
        {
            if(firm == null)
            {
                throw new ArgumentNullException(nameof(firm));
            }

            _context.Firms.Add(firm);
        }

        public IEnumerable<Firm> GetAllFirms()
        {
            return _context.Firms.ToList();

        }

        public bool SaveChanges()
        {
           return _context.SaveChanges() >= 0;
        }
    }
}