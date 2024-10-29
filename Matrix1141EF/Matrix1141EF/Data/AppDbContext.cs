using Matrix1141EF.Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Matrix1141EF.Data
{
    public class AppDbContext : IdentityDbContext<User, Role, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserProduct> UserProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
           .Property(p => p.Price)
           .HasColumnType("decimal(18,2)");

            builder.Entity<UserProduct>()
            .HasOne(up => up.User)
            .WithMany(u => u.UserProducts)
            .HasForeignKey(up => up.UserID)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserProduct>()
            .HasOne(up => up.Product)
            .WithMany(p => p.UserProducts)
            .HasForeignKey(up => up.ProductID)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserProduct>().HasKey(up=>new { up.UserID, up.ProductID });
        }
    }
}
