using FileService.Models;
using Microsoft.EntityFrameworkCore;

namespace FileService.Data
{
    public class CertficateRepo : ICertificateRepo
    {
        private readonly FileDbContext _fileDbContext;

        public CertficateRepo(FileDbContext fileDbContext)
        {
            _fileDbContext = fileDbContext;
        }

        public bool SaveChanges()
        {
            return _fileDbContext.SaveChanges() >= 0;
        }

        public async Task<Certificate> GetCertficateById(int id)
        {
            var result = await _fileDbContext.Certificates.FirstOrDefaultAsync(d => id == d.Id);
            return result;
        }

        public bool UploadCertificateToDb(Certificate certificate)
        {
            _fileDbContext.Add(certificate);
            return SaveChanges();
        }


        public async Task<bool> DeleteCertificateById(int id)
        {
            var foundCertificate = await GetCertficateById(id);

            if (foundCertificate != null)
            {
                _fileDbContext.Certificates.Remove(foundCertificate);
                SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
