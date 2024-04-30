using FileService.Models;

namespace FileService.Data;

public interface ICertificateRepo
{
    bool SaveChanges();
    Task<Certificate> GetCertficateById(int id);
    Task<bool> DeleteCertificateById(int id);
    bool UploadCertificateToDb(Certificate certificate);
}

