using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.Systemsetting;

namespace TimeTracker.Service.Services.IServices
{
    public interface ISystemSettingService
    {
        Task<IEnumerable<SystemSettingDto>> GetAll();
        Task<SystemSettingDto> GetById(int id);
        Task<SystemSettingDto> Add(SystemSettingDto systemSettingDto);
        Task<SystemSettingDto> Update(int id, SystemSettingDto systemSettingDto);
        Task<bool> Delete(int id);
    }
}
