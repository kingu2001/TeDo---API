using AutoMapper.Internal.Mappers;
using Microsoft.EntityFrameworkCore;
using TestDocumentService.Models;

namespace TestDocumentService.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) {}
        public DbSet<TestDocument> TestDocuments {get; set;}

    }
}