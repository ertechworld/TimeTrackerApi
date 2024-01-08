using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TimeTracker.DTO.Leavetype;
using TimeTracker.Service.Data;
using TimeTracker.Service.Entities;
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
