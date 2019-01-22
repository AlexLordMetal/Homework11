using System.Data.Entity;

namespace Korovans
{
    public class FactionsDbContext : DbContext
    {
        public DbSet<Faction> Factions { get; set; }
        public DbSet<Fighter> Fighters { get; set; }
    }
}
