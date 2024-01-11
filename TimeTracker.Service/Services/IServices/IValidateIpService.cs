using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.Systemsetting;

namespace TimeTracker.Service.Services.IServices
{
    public interface IValidateIpService
    {
        Task<bool> ValidateIpAddressAsync(string ipAddress);
    }
}