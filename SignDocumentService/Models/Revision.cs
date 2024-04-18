namespace SignDocumentService.Models
{
    public class Revision
    {
        public int Number { get; set; }
        public string PageAffected { get; set; }
        public string SectionAffected { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        //navigation property
        public SignedDocument SignedDocument { get; set; }
    }
}