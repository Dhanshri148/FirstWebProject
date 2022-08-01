﻿using LMS.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS.Web.Data
{

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

    }
}
