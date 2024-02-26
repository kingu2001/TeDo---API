using Microsoft.EntityFrameworkCore;
using TestDocumentService.Data.Context;
using TestDocumentService.Data.Interfaces;
using TestDocumentService.Models;

namespace TestDocumentService.Data.Repositorys
{
    public class TestDocumentRepo : ITestDocumentRepo
    {
        private readonly AppDbContext _context;

        public TestDocumentRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateTestDocument(TestDocument testDocument)
        {
            if(testDocument == null)
            {
                throw new ArgumentNullException(nameof(testDocument));
            }

            _context.TestDocuments.Add(testDocument);
        }

        public IEnumerable<TestDocument> GetAllTestDocument()
        {

            return _context.TestDocuments.ToList();
		}

        public TestDocument GetTestDocumentById(int id)
        {
            var result = _context.TestDocuments.FirstOrDefault(t => t.Id == id);

            if(result == null)
            {   
                throw new ArgumentNullException(nameof(result));
            }

             return result;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}