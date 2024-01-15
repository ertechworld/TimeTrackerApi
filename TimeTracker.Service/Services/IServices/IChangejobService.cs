using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.ChangejobDto;

using TimeTracker.DTO.Userattendance;
using TimeTracker.Service.Entities;

namespace TimeTracker.Service.Services.IServices
{
    public interface IChangejobService
    {
      
        Task<bool> Update(int id, ChangejobDto changejobDto);

      
    }
}
