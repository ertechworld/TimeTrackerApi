using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.User;
using TimeTracker.Service.Models;

namespace TimeTracker.Service.Services.IServices
{
    public interface IUserService
    {
        Task<UserResponseDto> Authenticate(UserRequestDto userRequestDto);
    }
}
