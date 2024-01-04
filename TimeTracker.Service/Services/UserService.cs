using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.User;
using TimeTracker.Service.Data;
using TimeTracker.Service.Services.IServices;
using Microsoft.Extensions.Options;
using TimeTracker.Service.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Utility;

namespace TimeTracker.Service.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        public UserService(ApplicationDbContext context,IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
        }

        public DateTime Expires { get; private set; }

        public async Task<UserResponseDto> Authenticate(UserRequestDto userRequestDto)
        {
            //var user = _mapper.Map<User>(userRequestDto);
            //var user = _mapper.Map<User>(userRequestDto);
            var result =  _context.Users.Where(x => x.Password == userRequestDto.Password).FirstOrDefault();
            
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
                    new Claim(ClaimTypes.Role,"Admin"),
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
        
    }
}
