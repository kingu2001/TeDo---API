using Microsoft.EntityFrameworkCore;
using TestDocumentService.Models;

namespace TestDocumentService.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) {}
        public DbSet<TestDocument> TestDocuments {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FirmTestDocument>()
                .HasKey(ft => new { ft.FirmId, ft.TestDocumentId });

            modelBuilder.Entity<FirmTestDocument>()
                .HasOne(ft => ft.Firm)
                .WithMany(f => f.FirmTestDocuments)
                .HasForeignKey(ft => ft.FirmId);

            modelBuilder.Entity<FirmTestDocument>()
                .HasOne(ft => ft.TestDocument)
                .WithMany(t => t.FirmTestDocuments)
                .HasForeignKey(ft => ft.TestDocumentId);

            modelBuilder.Entity<TestDocumentParticipant>()
                .HasKey(tp => new { tp.TestDocumentId, tp.ParticipantId });

            modelBuilder.Entity<TestDocumentParticipant>()
                .HasOne(tp => tp.TestDocument)
                .WithMany(t => t.TestDocumentParticipants)
                .HasForeignKey(tp => tp.TestDocumentId);

            modelBuilder.Entity<TestDocumentParticipant>()
                .HasOne(tp => tp.Participant)
                .WithMany(p => p.TestDocumentParticipant)
                .HasForeignKey(tp => tp.ParticipantId);
                
        }
    }
}