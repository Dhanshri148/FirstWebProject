using Microsoft.EntityFrameworkCore;
using WebsiteDemo.Web.Models;

namespace WebsiteDemo.Web.Data
{
    public class ApplicationDbContext:DbContext
    {

        public DbSet<Food> Foods { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }

        public DbSet<WebsiteDemo.Web.Models.Category> Category { get; set; }
    }
}
