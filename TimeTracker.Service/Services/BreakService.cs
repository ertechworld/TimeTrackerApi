using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.Break;
using TimeTracker.DTO.Jobtype;
using TimeTracker.Service.Data;
using TimeTracker.Service.Entities;
using TimeTracker.Service.Services.IServices;

namespace TimeTracker.Service.Services
{
    public class BreakService : IBreakService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public BreakService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BreakDto>> GetAll()
        {
            var breaks = await _context.Breaks.ToListAsync();
            return breaks.Select(breaks => _mapper.Map<Break, BreakDto>(breaks));
        }
    }
}
