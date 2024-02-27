namespace TestDocumentService.Models
{
    public class FirmTestDocument
    {
        public int FirmId { get; set; }
        public Firm Firm { get; set; }

        public int TestDocumentId { get; set; }
        public TestDocument? TestDocument { get; set; }
    }
}