using AutoMapper;
using Hotel2Listing.Data.Contract;
using Hotel2Listing.Data.Dtos;
using Hotel2Listing.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel2Listing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
   
    public class CountriesController : ControllerBase
    {
       
        private readonly IMapper _mapper;
        private readonly HotelDbContext _db;
        private readonly ICountriesRepository _countryRepo;
        public CountriesController(ICountriesRepository countryRepo,  IMapper mapper, HotelDbContext db)
        {
            _countryRepo = countryRepo;
            _mapper = mapper;
            this._db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountriesDto>>> GetCountries()
        {
            var country = await _countryRepo.GetAllAsync();
            var getObj = _mapper.Map<List<GetCountriesDto>>(country);
            return Ok(getObj);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CountriesDto>>GetCountry(int id)
        {

            var cotext = await _db.Countires.Include(a => a.HotelListings).FirstOrDefaultAsync(b => b.Id == id);
            //var country = await _countryRepo.GetDetails(id);
            //  if(country == null)
            //{
            //    return NotFound();
            //}
            //var mapObj = _mapper.Map<country>(CountriesDto);
            return Ok(cotext);
        }

        [HttpPut("{id}")]
        [Authorize]

        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updatecountryDto)
        {
            if(id != updatecountryDto.Id)
            {
                return BadRequest();
            }
            //_db.Entry(country).State = EntityState.Modified;
            var country = await _countryRepo.GetAsync(id);
            if(country is null)
            {
                return NotFound();
            }
             _mapper.Map(updatecountryDto, country);
            try
            {
                await _countryRepo.UpdateAsync(country);
            }
            catch (Exception)
            {
                if (!await _countryRepo.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    return NotFound();
                }

                throw;
                
            }
            return NoContent();
        }


        [HttpPost, Route("PostCountry")]
        [Authorize(Roles = "Adminstrator, User")]

        public async Task<ActionResult<Country>> PostCountry(CreateCountryDto countryDto)
        {
   
            var mapObj = _mapper.Map<Country>(countryDto);
            await  _countryRepo.AddAsync(mapObj);
            return CreatedAtAction("GetCountry", new { id = mapObj.Id }, mapObj);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Adminstrator")]

        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countryRepo.GetAsync(id);
            if(country == null)
            {
                return NotFound();
            }
            _countryRepo.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
             return await _countryRepo.Exists(id);
            
        }
    }
}
