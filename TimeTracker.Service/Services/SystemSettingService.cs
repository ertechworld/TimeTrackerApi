using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TimeTracker.DTO.Jobtype;
using TimeTracker.DTO.Systemsetting;
using TimeTracker.Service.Data;
using TimeTracker.Service.Entities;
using TimeTracker.Service.Services.IServices;

namespace TimeTracker.Service.Services
{
    public class SystemSettingService : ISystemSettingService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public SystemSettingService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SystemSettingDto>> GetAll()
        {
            var systemSettings = await _context.SystemSettings
                .Include(s => s.Tenant) 
                .ToListAsync();
            return systemSettings.Select(setting => _mapper.Map<Systemsetting, SystemSettingDto>(setting));
        }

        public async Task<SystemSettingDto> GetById(int id)
        {
            var systemSetting = await _context.SystemSettings.FindAsync(id);

            if (systemSetting == null)
                return null;

            return _mapper.Map<Systemsetting, SystemSettingDto>(systemSetting);
        }

        public async Task<SystemSettingDto> Add(SystemSettingDto systemSettingDto)
        {
            var systemSetting = _mapper.Map<SystemSettingDto, Systemsetting>(systemSettingDto);

            _context.SystemSettings.Add(systemSetting);
            await _context.SaveChangesAsync();

            return _mapper.Map<Systemsetting, SystemSettingDto>(systemSetting);
        }


        public async Task<SystemSettingDto> Update(int id, SystemSettingDto systemSettingDto)
        {
            var existingSetting = await _context.SystemSettings.FindAsync(id);

            if (existingSetting == null)
                return null;

            _mapper.Map(systemSettingDto, existingSetting);

            await _context.SaveChangesAsync();

            return _mapper.Map<Systemsetting, SystemSettingDto>(existingSetting);
        }
        public async Task<bool> Delete(int id)
        {
            var systemSetting = await _context.SystemSettings.FindAsync(id);
            if (systemSetting == null)
                return false;
            _context.SystemSettings.Remove(systemSetting);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
