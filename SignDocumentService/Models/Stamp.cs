namespace SignDocumentService.Models
{
    public class Stamp
    {
        public int Id { get; set; }
        public byte[] Signature { get; set; }
        public string Comment { get; set; }
        public string Date { get; set; }
        //navigation property
        public SignedDocument SignedDocument { get; set; }
    }
}