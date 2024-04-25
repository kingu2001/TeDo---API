namespace SignDocumentService.Models
{
    public class SignedDocument : Document
    {
        // Navigation properties
        public List<Punch>? Punches { get; set; }
        public List<Revision>? Revisions { get; set; }
        public List<Stamp> Stamps { get; set; }
    }
}
