using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Service.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? UploadedFiles { get; set; } = string.Empty;
        [NotMapped]
        public string Token { get; set; } = string.Empty;
        public string? HourlyRate { get; set; }
        public string? WorkingHours { get; set; }
        public bool? IsBreakIncluded { get; set; }
        public virtual Role? Role { get; set; }
        public bool? IsDeleted { get; set; }
        public virtual Userattendance? UserAttendances { get; set; }
    }
}
