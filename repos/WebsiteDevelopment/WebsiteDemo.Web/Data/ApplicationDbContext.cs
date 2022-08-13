using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using WebsiteDemo.Web.Models;

namespace WebsiteDemo.Web.Data
{
   
    public class ApplicationDbContext:DbContext
    {

        public DbSet<Food> Foods { get; set; }

        public DbSet<Order> Order { get; set; }
       
        public DbSet<Customer> Customer { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }

        public DbSet<WebsiteDemo.Web.Models.Category> Category { get; set; }
        public object Categories { get; internal set; }
    }
}
