using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.Jobtype;

using TimeTracker.DTO.Status;
using TimeTracker.Service.Entities;

namespace TimeTracker.Service.Services.IServices
{
    public interface IJobtypeService
    {
        Task<IEnumerable<JobtypeDto>> GetAll();
    }
}
