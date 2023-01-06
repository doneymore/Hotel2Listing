using Hotel2Listing.Data.Dtos.UserDto;
using Hotel2Listing.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel2Listing.Data.Contract
{
    public interface IUser
    {
        Task<IEnumerable<IdentityError>> Register(UserDto userDto);
 
        Task<AuthResponseDto> Login(LoginUser login);

        Task<string> CreateRefreshToken();

        Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);

         
        //Task Register(LoginDto loginDto);
    }
}
