using Matrix1141EF.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Matrix1141EF.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
