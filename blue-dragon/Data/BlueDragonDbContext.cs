
using blue_dragon.Models.V1;
using Microsoft.EntityFrameworkCore;

namespace blue_dragon.Data
{
    public class BlueDragonDbContext : DbContext
    {

        // for injecting db context
        public BlueDragonDbContext(DbContextOptions<BlueDragonDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        // register Model here
        public DbSet<Activity> Activities { get; set; }
        public DbSet<User> Users { get; set; }

    }

}
