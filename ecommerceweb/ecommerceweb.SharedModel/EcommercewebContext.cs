using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerceweb.Domain;

namespace ecommerceweb.SharedModel
{
    public class EcommercewebContext : DbContext
    {
        public EcommercewebContext(DbContextOptions<EcommercewebContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    

        public void OnConfigurating(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.Entity<Product>()
                .Property(q => q.Name)
                .HasColumnName("FullName");

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=DESKTOP-AB57MQ4\\SQLEXPRESS;Initial Catalog=EcommercewebAppDb;Integrated Security=True")
                .UseLazyLoadingProxies()
                .LogTo(Console.WriteLine, new[] {
                        DbLoggerCategory.Model.Name,
                        DbLoggerCategory.Database.Command.Name,
                        DbLoggerCategory.Database.Transaction.Name,
                        DbLoggerCategory.Query.Name,
                        DbLoggerCategory.ChangeTracking.Name,
                },
                       LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(q => q.Name)
                .HasColumnName("FullName");
        }*/
    }

}
