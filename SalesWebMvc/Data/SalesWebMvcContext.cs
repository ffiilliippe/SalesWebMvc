using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Data
{
    public class SalesWebMvcContext : DbContext
    {
        public SalesWebMvcContext (DbContextOptions<SalesWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Department> Department { get; set; }
        public DbSet<Models.SalesRecord> SalesRecords { get; set; }
        public DbSet<Models.Seller> Sellers { get; set; }
    }
}
