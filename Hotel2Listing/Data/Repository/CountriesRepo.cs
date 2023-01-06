using Hotel2Listing.Data.Contract;
using Hotel2Listing.Data.Dtos;
using Hotel2Listing.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel2Listing.Data.Repository
{
    public class CountriesRepo : GenericRepository<Country>, ICountriesRepository
    {
        private readonly HotelDbContext _db;

        public CountriesRepo(HotelDbContext db) : base(db)
        {
            this._db = db;
        }

        public async Task<Country> GetDetails(int id)
        {
            return await _db.Countires.Include(a => a.HotelListings).FirstOrDefaultAsync(z => z.Id == id);
        }
    }
}
