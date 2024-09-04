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

        public DbSet<Fees> YourEntities { get; set; }
    }

}
