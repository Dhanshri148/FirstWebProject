using HomePage.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace HomePage.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products {get;set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }

        public DbSet<HomePage.Web.Models.Category> Category { get; set; }
    }
}
