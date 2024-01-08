using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TimeTracker.DTO.Status;

namespace TimeTracker.Service.Services.IServices
{
    public interface IStatusService
    {
        Task<IEnumerable<StatusDto>> GetAll();
    }
}
