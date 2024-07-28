using Microsoft.EntityFrameworkCore;

namespace BasicAPI.DBContext
{
    public class ClientDBContext : DbContext
    {
        public ClientDBContext(DbContextOptions<ClientDBContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Task> Task { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Tasks)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
