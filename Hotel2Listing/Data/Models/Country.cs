using System.Collections.Generic;

namespace Hotel2Listing.Data.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public virtual IList<HotelModel> HotelListings { get; set; }
    }
}