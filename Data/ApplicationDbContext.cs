using BigFootWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigFootWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Interaction> Interactions { get; set; }

        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=SKULLKID-AORUS;Initial Catalog=TestDB; Trusted_Connection=True; TrustServerCertificate=True;");
            }
        }
    }
}
