using DocumentService.Models;
using FileService;
using FileService.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentService.Data
{
    public class FileDbContext : DbContext
    {
        public FileDbContext(DbContextOptions<FileDbContext> opt) : base(opt) {}

        public DbSet<Document> Documents { get; set; }
        public DbSet<SignedDocument> SignedDocuments { get; set; }
        public DbSet<Punch> Punches { get; set; }
        public DbSet<Stamp> Stamps { get; set; }
        public DbSet<Revision> Revisions { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
    }
}

