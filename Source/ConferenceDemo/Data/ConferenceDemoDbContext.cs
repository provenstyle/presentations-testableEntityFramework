using System.Data.Entity;
using Data.Entities;

namespace Data
{
    public class ConferenceDemoDbContext : DbContext
    {
        public ConferenceDemoDbContext(string connectionString)
            : base(connectionString)
        { }

        public DbSet<Talk> Talks { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
    }
}