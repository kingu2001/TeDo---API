using TestDocumentService.Models;

namespace TestDocumentService.Data.Interfaces
{
    public interface ITestDocumentRepo
    {
        bool SaveChanges();
        IEnumerable<TestDocument> GetAllTestDocument();
        TestDocument GetTestDocumentById(int id);
        void CreateTestDocument(TestDocument testDocument);
    }
}