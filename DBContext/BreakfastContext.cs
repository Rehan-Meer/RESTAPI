using Microsoft.EntityFrameworkCore;

namespace BasicAPI.DBContext
{
    public class BreakfastContext : DbContext
    {
        public BreakfastContext(DbContextOptions<BreakfastContext> options) : base(options){}

        public DbSet<Breakfast> Breakfast { get; set; }
    }
}
