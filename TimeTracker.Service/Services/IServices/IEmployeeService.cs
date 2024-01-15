using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TimeTracker.DTO.User;
using TimeTracker.Service.Entities;

namespace TimeTracker.Service.Services.IServices
{
    public interface IEmployeeService
    {
        

        Task<IEnumerable<UserDto>> GetAllUsers(string? querySearch);
    }
}
