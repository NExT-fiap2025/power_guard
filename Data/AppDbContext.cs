using Microsoft.EntityFrameworkCore;
using PowerGuard.Models;

namespace PowerGuard.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<EnergyEvent> EnergyEvents => Set<EnergyEvent>();
}
