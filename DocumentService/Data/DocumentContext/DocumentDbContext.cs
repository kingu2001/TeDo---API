using DocumentService.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentService.Data
{
    public class DocumentDbContext : DbContext
    {
        public DocumentDbContext(DbContextOptions<DocumentDbContext> opt) : base(opt) {}

        public DbSet<Document> Documents { get; set; }
    }
}

