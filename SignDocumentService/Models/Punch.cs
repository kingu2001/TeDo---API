namespace SignDocumentService.Models
{
    public class Punch
    {
        public string Test { get; set; }
        public int PunchNumber { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public string Action { get; set; }
        //Navigation property
        public SignedDocument SignedDocument { get; set; }
    }
}