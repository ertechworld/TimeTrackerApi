using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.DTO.User
{
    public class UserResponseDto:UserRequestDto
    {
        public string Email { get; set; } = string.Empty;
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? UploadedFiles { get; set; } = string.Empty;
        [NotMapped]
        public string Token { get; set; } = string.Empty;
        public string? RoleName { get; set; }
    }
}
