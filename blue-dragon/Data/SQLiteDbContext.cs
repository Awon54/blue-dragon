
using blue_dragon.Models.V1;
using Microsoft.EntityFrameworkCore;
using System.Security.Permissions;

namespace blue_dragon.Data
{
    public class SQLiteDbContext : DbContext
    {

        // TODO remove this
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite("Data Source=bluedragon.db");

        // for injecting db context
        public SQLiteDbContext(DbContextOptions<SQLiteDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
   
        }

        // register Model here
        public DbSet<Activity> Activities { get; set; }
    }

}
