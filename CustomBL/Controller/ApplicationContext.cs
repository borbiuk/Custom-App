using CustomBL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomBL.Controller
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Electric> Electrics { get; set; }
        public DbSet<Hybrid> Hybrids { get; set; }
        public DbSet<MotorCycle> MotorCycles { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Trucs> Trucs { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CustomAppDB;Trusted_Connection=True;");
        }
    }
}
