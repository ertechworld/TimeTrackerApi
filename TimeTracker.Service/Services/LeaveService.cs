using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.Leave;
using TimeTracker.DTO.Product;
using TimeTracker.DTO.Task;
using TimeTracker.Service.Data;
using TimeTracker.Service.Entities;
using TimeTracker.Service.Models;
using TimeTracker.Service.Services.IServices;
using Task = TimeTracker.Service.Models.Task;

namespace TimeTracker.Service.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public LeaveService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<LeaveRequestDto> Add(LeaveRequestDto leaveDto)
        {
            var leave = _mapper.Map<Leave>(leaveDto);
            _context.Leaves.Add(leave);
            await _context.SaveChangesAsync();
            return _mapper.Map<LeaveRequestDto>(leave);
        }
        public async Task<LeaveRequestDto> Delete(int id)
        {
            Leave leave = await _context.Leaves.FindAsync(id);
            if (leave != null)
            {
                leave.IsDeleted = true;
                await _context.SaveChangesAsync();
                return _mapper.Map<LeaveRequestDto>(leave);  
            }
            return null; 
        }
        public async Task<LeaveRequestDto> GetById(int id)
        {
            Leave leave = await _context.Leaves.FindAsync(id);
            if (leave != null)
            {
                return _mapper.Map<LeaveRequestDto>(leave);
            }
            return null;
        }
        public async Task<IEnumerable<LeaveResponseDto>> GetAll()
        {
            var leaves = await _context.Leaves
                .Include(l => l.LeaveType)
                .ToListAsync();

            return leaves.Select(leave => _mapper.Map<Leave, LeaveResponseDto>(leave));
        }
        public async Task<LeaveRequestDto> Update(int id, LeaveRequestDto leaveDto)
        {
            var leave = await _context.Leaves.FindAsync(id);
            if (leave != null)
            {
                _mapper.Map(leaveDto, leave);
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<LeaveRequestDto>(leave);
        }  
    }
}

