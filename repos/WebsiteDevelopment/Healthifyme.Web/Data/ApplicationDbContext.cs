using Healthifyme.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Healthifyme.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Dietition> Dietitions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DietChart> DietCharts { get; set; }
        public DbSet<ExerciseCategory> ExerciseCategories { get; set; }
        public DbSet<Exercise> Exercises { get; set; }  
        public DbSet<DietCategory> DietCategories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }

        public DbSet<Healthifyme.Web.Models.Payment> Payment { get; set; }
    }
}
