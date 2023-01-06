using AutoMapper;
using Hotel2Listing.Data.Dtos;
using Hotel2Listing.Data.Dtos.HotelDtos;
using Hotel2Listing.Data.Dtos.UserDto;
using Hotel2Listing.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel2Listing.Data.MapperConfig
{
    public class MapConfig: Profile
    {
        public MapConfig()
        {
            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Country, GetCountriesDto>().ReverseMap();
            CreateMap<Country, CountriesDto>().ReverseMap();
            CreateMap<Country, UpdateCountryDto>().ReverseMap();

            CreateMap<HotelModel, HotelDto>().ReverseMap();
            CreateMap<HotelModel, HotelCreateDto>().ReverseMap();
            CreateMap<HotelModel, HotelUpdateDto>().ReverseMap();
            CreateMap<HotelModel, HotelFetchByIdDto>().ReverseMap();

            CreateMap<ApiUser, UserDto>().ReverseMap();
        }
    }
}
