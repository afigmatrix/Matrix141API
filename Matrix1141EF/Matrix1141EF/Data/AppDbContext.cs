using Matrix1141EF.Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Matrix1141EF.Data
{
    public class AppDbContext : IdentityDbContext<User,Role,int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Library> Libraries{ get; set; }
    }
}
