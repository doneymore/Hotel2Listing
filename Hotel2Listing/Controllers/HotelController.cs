using AutoMapper;
using Hotel2Listing.Data.Contract;
using Hotel2Listing.Data.Dtos.HotelDtos;
using Hotel2Listing.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel2Listing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _hotelRep;
        private readonly IMapper _mapper;

        public HotelController(IHotelRepository hotelRep, IMapper mapper)
        {
            this._hotelRep = hotelRep;
            this._mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IList<HotelDto>>> GetHotels()
        {
            var getHotels = await _hotelRep.GetAllAsync();
            var objMap = _mapper.Map<List<HotelDto>>(getHotels);
            return Ok(objMap);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<HotelFetchByIdDto>> GetHotelsById(int id)
        {
            var getHById = await _hotelRep.GetAsync(id);
            if(getHById is null)
            {
                return NotFound();
            }
            var mapObj = _mapper.Map<HotelFetchByIdDto>(getHById);
            return Ok(mapObj);
        }

        [HttpPost]

        public async Task<ActionResult<HotelModel>> CreateHotels(HotelCreateDto hotelCreate)
        {
            var mapObj = _mapper.Map<HotelModel>(hotelCreate);
             await _hotelRep.AddAsync(mapObj);
            return Ok();
                //CreatedAtAction("GetAllAsync", new { id = mapObj.Id }, mapObj);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateHotels(int id, HotelUpdateDto updateDto)
        {
            if(id != updateDto.Id)
            {
                return BadRequest();
            }
            var getHotels = await _hotelRep.GetAsync(id);
            if(getHotels is null)
            {
                return NotFound();
            }
            _mapper.Map(updateDto, getHotels);
            try
            {
                await _hotelRep.UpdateAsync(getHotels);
            }
            catch (Exception)
            {
                if(!await _hotelRep.Exists(id))
                {
                    return BadRequest();
                }

                throw;
               
            }
            return NoContent();

        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteHotel(int id)
        {
            var getHotel = await _hotelRep.GetAsync(id);
            if(getHotel is null)
            {
                return NotFound();
            }
            _hotelRep.DeleteAsync(id);
            return NoContent();
        }
    }
}
