using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.Leavetype;
using TimeTracker.DTO.Product;
using TimeTracker.DTO.Status;
using TimeTracker.Service.Data;
using TimeTracker.Service.Entities;
using TimeTracker.Service.Models;
using TimeTracker.Service.Services.IServices;

namespace TimeTracker.Service.Services
{
    public class LeavetypeService : ILeavetypeService
    {
        private readonly ApplicationDbContext _context; 
        private readonly IMapper _mapper;

        public LeavetypeService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LeavetypeDto>> GetAll()
        {
            var leavetypes = await _context.Leavetypes.ToListAsync();
            return leavetypes.Select(leavetype => _mapper.Map<Leavetype, LeavetypeDto>(leavetype));
        }

    }

}
