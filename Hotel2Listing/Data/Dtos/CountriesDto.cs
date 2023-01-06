using Hotel2Listing.Data.Dtos.HotelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel2Listing.Data.Dtos
{
    public class CountriesDto: BaseDto
    {
        public int Id { get; set; }
    
        public List<HotelDto> Hotels { get; set; }
    }
}
