using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel2Listing.Data.Dtos.HotelDtos
{
    public abstract class HotelBaseDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double? Rating { get; set; }
        
        public int CountryId { get; set; }
    }
}
