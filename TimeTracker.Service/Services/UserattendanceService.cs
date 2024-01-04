using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.Product;
using TimeTracker.DTO.Status;
using TimeTracker.DTO.Userattendance;
using TimeTracker.Service.Data;
using TimeTracker.Service.Entities;
using TimeTracker.Service.Models;
using TimeTracker.Service.Services;
using TimeTracker.Service.Services.IServices;

namespace TimeTracker.Service.Services
{
    public class UserattendanceService:IUserattendanceService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UserattendanceService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserattendanceDto> Add(UserattendanceDto userattendanceDto)
        {
            var userattendance = _mapper.Map<Userattendance>(userattendanceDto);
            await _context.Userattendances.AddAsync(userattendance);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserattendanceDto>(userattendance);
        }

        public async Task<UserattendanceDto> Update(int id, UserattendanceDto userattendanceDto)
        {
            var userattendance = await _context.Userattendances.FindAsync(id);

            if (userattendance != null)
            {
                _mapper.Map(userattendanceDto, userattendance);
                await _context.SaveChangesAsync();
            }

            return _mapper.Map<UserattendanceDto>(userattendance);
        }

    }
}
