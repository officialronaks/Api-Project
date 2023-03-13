using Location;
using Microsoft.EntityFrameworkCore;
using User;

namespace Project1.data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<location> locations { get; set; }
        public DbSet<user> users { get; set; }
    }
}
