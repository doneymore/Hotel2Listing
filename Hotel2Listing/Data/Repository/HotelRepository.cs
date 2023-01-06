using Hotel2Listing.Data.Contract;
using Hotel2Listing.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel2Listing.Data.Repository
{
    public class HotelRepository : GenericRepository<HotelModel>, IHotelRepository
    {
        private readonly HotelDbContext _db;

        public HotelRepository(HotelDbContext db) : base(db)
        {
            this._db = db;
        }

        public async Task<HotelModel> GetHotelWithCountries(int id)
        {
          return await _db.HotelM.Include(a => a.Country).FirstOrDefaultAsync(a => a.Id == id);
           
        }
    }
}
