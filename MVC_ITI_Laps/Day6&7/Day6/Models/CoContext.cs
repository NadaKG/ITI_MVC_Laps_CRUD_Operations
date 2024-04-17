using Microsoft.EntityFrameworkCore;

namespace Day6.Models
{
    public class CoContext: DbContext
    {
        public CoContext():base()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=OrderCustomerDay6;User Id=sa; password=123; TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
