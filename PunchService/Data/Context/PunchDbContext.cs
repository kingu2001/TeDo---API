using Microsoft.EntityFrameworkCore;
using PunchService.Model;

namespace PunchService.Data;
public class PunchDbContext : DbContext
{
    public PunchDbContext(DbContextOptions<PunchDbContext> opt) : base(opt) {}
    public DbSet<Punch> Punches;
}