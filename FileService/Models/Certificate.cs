using System.ComponentModel.DataAnnotations;

namespace FileService.Models
{
    public class Certificate
    {
        [Key]
        public int Id { get; set; }
        public string CertificateOwner { get; set; }
        public byte[] CertificateData { get; set; }
    }
}
