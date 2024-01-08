using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.Leavetype;

using TimeTracker.DTO.Status;
using TimeTracker.Service.Entities;

namespace TimeTracker.Service.Services.IServices
{
    public interface ILeavetypeService
    {
        Task<IEnumerable<LeavetypeDto>> GetAll();
    }
}
