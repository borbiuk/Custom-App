using CustomBL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomBL.Controller
{
    public class CustomApplicationContext : DbContext
    {
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Truck> Trucs { get; set; }

        public CustomApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CustomAppDB;Trusted_Connection=True;");
        }
    }
}
