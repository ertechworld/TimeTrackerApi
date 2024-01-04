using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.Product;
using TimeTracker.DTO.Status;
using TimeTracker.Service.Data;
using TimeTracker.Service.Entities;
using TimeTracker.Service.Models;
using TimeTracker.Service.Services.IServices;

namespace TimeTracker.Service.Services
{
    public class JobTypeService : IJobtypeService
    {
        private readonly ApplicationDbContext _context; 
        private readonly IMapper _mapper;

        public JobTypeService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<JobtypeDto>> GetAll()
        {
            var jobtypes = await _context.Jobtypes.ToListAsync();
            return jobtypes.Select(jobtype => _mapper.Map<Jobtype, JobtypeDto>(jobtype));
        }

    }

}
