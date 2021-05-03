using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleInfoService.Models;

namespace VehicleInfoService.Data
{
    public class AtsDbContext : DbContext
    {
        //public DbSet<Vehicle> Books { get; set; }
        public AtsDbContext(DbContextOptions<AtsDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasNoKey();
        }
    }
}
