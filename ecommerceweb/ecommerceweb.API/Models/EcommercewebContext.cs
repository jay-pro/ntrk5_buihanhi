using ecommerceweb.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerceweb.API.Models
{
    public class EcommercewebContext: DbContext
    {
        public EcommercewebContext(DbContextOptions<EcommercewebContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Account> Account { get; set; }
        //public DbSet<Admin> Admin { get; set; }
        //public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        //public DbSet<Rating> Rating { get; set; }

    }
}
