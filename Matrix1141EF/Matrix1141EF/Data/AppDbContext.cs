using Matrix1141EF.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Matrix1141EF.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
    }
}
