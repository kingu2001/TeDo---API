using FileService.Models;

namespace FileService.Data.Repositories
{
    public interface ICertificateRepo
    {
        bool SaveChanges();
        Task<IEnumerable<Certificate>> GetAllCertificates();
        Task<Certificate> GetCertficateById(int id);
        Task<bool> DeleteCertificateById(int id);
        bool UploadCertificateToDb(Certificate certificate);
    }
}
