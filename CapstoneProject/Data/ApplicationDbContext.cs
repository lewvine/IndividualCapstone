using CapstoneProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Customer> customers { get; set; }
        public DbSet<Salesperson> salespeople { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<Appointment> appointments { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Name = "Salesperson",
                    NormalizedName = "SALESPERSON"
                },
                new IdentityRole
                {
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                }
                );
            builder.Entity<Grass>()
                .HasData(
                new Grass
                {
                    GrassID = 1,
                    Name = "Tall Fescue",
                    Cost = 2.50
                },
                new Grass
                {
                    GrassID = 2,
                    Name = "Bermuda",
                    Cost = 3.25
                },
                new Grass
                {
                    GrassID = 3,
                    Name = "Kentucky Bluegrass",
                    Cost = 4.00
                });
        }
    }
}
