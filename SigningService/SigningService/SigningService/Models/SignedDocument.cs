namespace SigningService.Models
{
    public class SignedDocument : Document
    {
        public List<byte[]> Signatures { get; set; }
    }
}
