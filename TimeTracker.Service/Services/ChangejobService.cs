using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using TimeTracker.DTO.ChangejobDto;

using TimeTracker.DTO.Jobtype;
using TimeTracker.DTO.Leave;
using TimeTracker.DTO.Status;
using TimeTracker.DTO.Userattendance;
using TimeTracker.Service.Data;
using TimeTracker.Service.Entities;
using TimeTracker.Service.Services.IServices;

namespace TimeTracker.Service.Services
{
    public class ChangejobService : IChangejobService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ChangejobService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> Update(int id, ChangejobDto changejobDto)
        {
                var changejob = await _context.UserAttendances
                    .Include(c => c.Task)
                    .Include(c => c.Project)
                    .Include(c => c.JobType)
                    .FirstOrDefaultAsync(c => c.Id == id);
                if (changejob == null)
                {
                    return false;
                }    
                if (changejobDto.Description != null)
                {
                    changejob.Description = changejobDto.Description;
                }
                if (changejobDto.TaskId != null)
                {
                    changejob.TaskId = changejobDto.TaskId;
                }
                if (changejobDto.ProjectId != null)
                {
                    changejob.ProjectId = changejobDto.ProjectId;
                }
                if (changejobDto.JobTypeId != null)
                {
                    changejob.JobTypeId = changejobDto.JobTypeId;
                }
                await _context.SaveChangesAsync();
                return true;
        }
    }
}