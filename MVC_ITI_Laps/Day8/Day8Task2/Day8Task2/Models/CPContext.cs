using Microsoft.EntityFrameworkCore;
using Day8Task2.ViewModels;

namespace Day8Task2.Models
{
    public class CPContext: DbContext
    {
        public CPContext(DbContextOptions<CPContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
