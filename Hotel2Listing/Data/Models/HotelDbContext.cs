using Hotel2Listing.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel2Listing.Data.Models
{
    public class HotelDbContext: IdentityDbContext<ApiUser>
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options): base(options)
        {

        }

        public DbSet<HotelModel> HotelM { get; set; }
        public DbSet<Country> Countires { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfig());
            modelBuilder.ApplyConfiguration(new HotelConfig());
            
        }
    }
}
