namespace FileService.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        public string CertificateOwner { get; set; }
        public byte[] CertificateData { get; set; }
    }
}
