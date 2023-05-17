﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class MyDbContext : DbContext 
    {
        public MyDbContext(){ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyStoreDB"));
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            optionsBuilder.Entity<Category>().HasData(
                new Category { CategoriesId= 1, CategoryName = "Beverages"},
                new Category { CategoriesId= 2, CategoryName = "Condements"},
                new Category { CategoriesId = 3, CategoryName = "Confections" },
                new Category { CategoriesId = 4, CategoryName = "Dairy Products" },
                new Category { CategoriesId = 5, CategoryName = "Grains/Cereals" },
                new Category { CategoriesId = 6, CategoryName = "Meat/Poultry" },
                new Category { CategoriesId = 7, CategoryName = "Produce" },
                new Category { CategoriesId = 8, CategoryName = "Seafood" }
                );
        }
    }
}
