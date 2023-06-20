using Microsoft.EntityFrameworkCore;

namespace CrudOpsCoreVersion6.Models
{
    public class BrandContext : DbContext
    {
        public BrandContext(DbContextOptions<BrandContext> options): base (options)
        {

        }

        public DbSet<Brand> Brands { get; set; }

    }
}
