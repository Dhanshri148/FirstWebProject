using HMS.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace HMS.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Category> Categories { get; set; } 

        public DbSet<Customer> Customers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }

    }
}
