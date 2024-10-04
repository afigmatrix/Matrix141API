using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
namespace Matrix1141EF.Data.Entity
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }
    }
}
