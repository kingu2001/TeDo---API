using Microsoft.EntityFrameworkCore;
using TestDocumentService.Models;

namespace TestDocumentService.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) {}
        
        public DbSet<Firm> Firms {get; set;}  
        public DbSet<Punch> Punches {get; set;}
        public DbSet<Revision> Revisions {get; set;}
        public DbSet<TestDocument> TestDocuments {get; set;}
    }
}