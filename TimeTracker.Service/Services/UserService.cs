using AutoMapper;
using TimeTracker.DTO.User;
using TimeTracker.Service.Data;
using TimeTracker.Service.Services.IServices;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Http;

namespace TimeTracker.Service.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
     
        private readonly IMapper _mapper;
        public UserService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public DateTime Expires { get; private set; }

        public async Task<UserResponseDto> Login(UserRequestDto userRequestDto)
        {
            var result = _context.Users
            .Include(u => u.Role)
            .FirstOrDefault(x => x.Password == userRequestDto.Password);
            if (result == null)
            {
                return null;
            }
            //JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes("thisismysecrettoken");
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,result.FirstName),
                    new Claim(ClaimTypes.Email,result.Email),
                    new Claim(ClaimTypes.MobilePhone,result.PhoneNumber),
                    new Claim(ClaimTypes.Role, result.Role?.Name ?? "DefaultRole"),
                    new Claim(ClaimTypes.Hash,result.Password)
                }),
                Expires = DateTime.UtcNow.AddHours(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            result.Token = tokenHandler.WriteToken(token);
            return _mapper.Map<UserResponseDto>(result);
        }

        public async Task<bool> Logout(int userId)
        {
            var userAttendance = await _context.Userattendances
                    .FirstOrDefaultAsync(x => x.UserId == userId && x.IsActive == true);
            if (userAttendance == null)
            {
                return false;
            }
            if (userAttendance.CheckoutTime.HasValue)
            {
                return false;
            }
            userAttendance.CheckoutTime = DateTime.Now;
            userAttendance.IsLogOut = true;
            await _context.SaveChangesAsync();
            return true;
        }

    }


}

    

