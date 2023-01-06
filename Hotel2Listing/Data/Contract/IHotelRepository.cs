using Hotel2Listing.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel2Listing.Data.Contract
{
    public interface IHotelRepository: IGenericRepository<HotelModel>
    {
        Task<HotelModel> GetHotelWithCountries(int id);
    }
}
