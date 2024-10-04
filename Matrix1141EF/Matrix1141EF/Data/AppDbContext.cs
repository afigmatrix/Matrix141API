using Matrix1141EF.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Matrix1141EF.Data
{
    public class AppDBContext : DbContext 
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) 
        {
                
        }
        public DbSet<Product> Products { get; set; }
    }
}
