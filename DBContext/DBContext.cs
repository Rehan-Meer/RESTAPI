using Microsoft.EntityFrameworkCore;

namespace BasicAPI.DBContext
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Breakfast> Breakfast { get; set; }

        public DbSet<User> User { get; set; }
    }
}
