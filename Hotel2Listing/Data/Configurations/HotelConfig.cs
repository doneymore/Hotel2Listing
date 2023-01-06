using Hotel2Listing.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel2Listing.Data.Configurations
{
    public class HotelConfig : IEntityTypeConfiguration<HotelModel>
    {
        public void Configure(EntityTypeBuilder<HotelModel> builder)
        {
            builder.HasData(
                new HotelModel
                {
                    Id = 1,
                    Name = "Eko Hotel & Suit",
                    Address = "Nigeria",
                    CountryId = 1,
                    Rating = 4.5
                },
                 new HotelModel
                 {
                     Id = 2,
                     Name = "Raddison Blue",
                     Address = "Lagos",
                     CountryId = 3,
                     Rating = 4.0
                 },
                  new HotelModel
                  {
                      Id = 3,
                      Name = "Sharoton Hotel & Suit",
                      Address = "Abuja",
                      CountryId = 2,
                      Rating = 4.3
                  }

                );
        }
    }
}
