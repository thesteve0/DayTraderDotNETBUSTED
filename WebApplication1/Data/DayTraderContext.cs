using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace NetTrader.Data
{
    public class DayTraderContext : DbContext
    {
        // these properties map to tables in the database 
        public DbSet<Quoteejb> Quotes { get; set; }
        public DbSet<Holdingejb> Holding { get; set; }
        public DbSet<Accountejb> Accounts { get; set; }

        protected override void OnConfiguring(
          DbContextOptionsBuilder optionsBuilder)
        {
            // for Microsoft SQL Server 
            // optionsBuilder.UseSqlServer( 
            // @"Data Source=(localdb)\mssqllocaldb;" + 
            // "Initial Catalog=Northwind;" + 
            // "Integrated Security=true;"); 

            // for SQLite 
            optionsBuilder.UseSqlite(
              "Filename=../../../../Northwind.db");

            //@TODO need to find out what MySQL Looks like
        }

        protected override void OnModelCreating(
          ModelBuilder modelBuilder)
        {
            // example of using Fluent API instead of attributes 
            modelBuilder.Entity<Category>()
            .Property(category => category.CategoryName)
            .IsRequired()
            .HasMaxLength(40);
        }
    }
}
