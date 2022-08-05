using System;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }
        
        // This connects each entity class to the database
        // Each entity class needs its own DbSet property here
        public DbSet<Patient> Patients {get; set;} = null!;
    }
}