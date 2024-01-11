using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.Break;

namespace TimeTracker.Service.Services.IServices
{
    public interface IBreakService
    {
        Task<IEnumerable<BreakDto>> GetAll();
    }
}
