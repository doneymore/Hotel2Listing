using Hotel2Listing.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel2Listing.Data.Configurations
{
    public class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                 new Country
                 {
                     Id = 1,
                     Name = "Nigeria",
                     ShortName = "NG"
                 },
                   new Country
                   {
                       Id = 2,
                       Name = "Ghana",
                       ShortName = "Gh"
                   },
                     new Country
                     {
                         Id = 3,
                         Name = "Wales",
                         ShortName = "Ws "
                     }

                 );
        }
    }
}
