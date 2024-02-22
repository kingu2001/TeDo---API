using TestDocumentService.Models;

namespace TestDocumentService.Data.Interfaces
{
    interface ITestDocumentRepo
    {
        bool SaveChanges();
        IEnumerable<TestDocument> GetAllPTestDocument();
        TestDocument GetTestDocumentById(int id);
        void CreateTestDocument(TestDocument testDocument);
    }
}