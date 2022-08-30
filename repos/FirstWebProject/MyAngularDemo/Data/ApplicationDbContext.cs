using Microsoft.EntityFrameworkCore;

namespace MyAngularDemo.Data
{
    public class ApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
