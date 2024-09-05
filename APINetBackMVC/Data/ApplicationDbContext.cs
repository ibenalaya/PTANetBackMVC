using APINetBackMVC.Models.Entities;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

namespace APINetBackMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Fees> Fees { get; set; }
        public DbSet<Bank> Banks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            // Configure the primary key explicitly
            modelBuilder.Entity<Fees>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasKey(e => e.BIC); // Define BIC as the primary key
                entity.Property(e => e.BIC).IsRequired().HasMaxLength(50); // Adjust the length as needed
                entity.Property(e => e.Country).IsRequired().HasMaxLength(50); // Adjust the length as needed
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100); // Adjust the length as needed
            });
        }

    }

}
