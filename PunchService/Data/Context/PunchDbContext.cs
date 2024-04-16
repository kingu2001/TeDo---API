using Microsoft.EntityFrameworkCore;

namespace PunchService;

public class PunchDbContext : DbContext
{
    public PunchDbContext(DbContextOptions<PunchDbContext> opt) : base(opt) {}
    public DbSet<Punch> Punchs;
}
