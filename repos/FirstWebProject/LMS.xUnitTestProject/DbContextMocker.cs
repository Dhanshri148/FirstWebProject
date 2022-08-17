using LMS.Web.Data;
using LMS.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.xUnitTestProject
{
    public static class DbContextMocker
    {
        //NOTE:
        //    Since all tests run parallelly,
        //    Ensure that each test method gets its own locally scoped InMemory database

        public static ApplicationDbContext GetApplicationDbContext(string databasename)
        {
            //Create a fresh service provider for the InMemory Database instance.
            //
            var serviceProvider = new ServiceCollection()
                                    .AddEntityFrameworkInMemoryDatabase()
                                    .BuildServiceProvider();

            //Create a new options instance,
            //telling the context to use InMemory database and the new service provider.

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                               .UseInMemoryDatabase(databasename)
                               .UseInternalServiceProvider(serviceProvider)
                               .Options;

            //Create the instance of the DbContext (would be an InMemory databse)
            //NOTE: It will use the Schema as defined in the Data and Models folders
            var dbContext = new ApplicationDbContext(options);

            //Add entities to the InMemory database
            dbContext.SeedData();

            return dbContext;
        }

        internal static readonly Category[] TestData_Categories
        ={
            new Category
            {
                CategoryId = 1,
                CategoryName = "First Category"
            },

             new Category
            {
                CategoryId = 2,
                CategoryName = "Second Category"
            },

              new Category
            {
                CategoryId = 3,
                CategoryName = "Third Category"
            }
        };

        private static void SeedData(this ApplicationDbContext context)
        {
            context.Categories.AddRange(TestData_Categories);

            context.SaveChanges();
        }
    }
}
