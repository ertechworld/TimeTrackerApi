using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TimeTracker.DTO.Status;
using TimeTracker.Service.Data;
using TimeTracker.Service.Entities;
using TimeTracker.Service.Services.IServices;

namespace TimeTracker.Service.Services
{
    public class StatusService : IStatusService
    {
        private readonly ApplicationDbContext _context; 
        private readonly IMapper _mapper;

        public StatusService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StatusDto>> GetAll()
        {
            var status = await _context.Status.Where(x => x.IsDeleted != true).ToListAsync();
            return status.Select(status => _mapper.Map<Status, StatusDto>(status));
        }

    }

}
