using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.Userattendance;

namespace TimeTracker.DTO.Employee
{
    public  class EmployeeDto
    {
       public int Id { get; set; }

        public string? Login { get; set; }

        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

        public string? Description { get; set; }

        public int? RoleId { get; set; }


        public string? PhoneNumber { get; set; }

      //  public int? StaffStatusId { get; set; }

     

        public string? Color { get; set; }

        public int? SerialNumber { get; set; }

        public int? DisplayNumber { get; set; }

        public string? FilePath { get; set; }
        public bool? IsDeleted { get; set; }

        public int? CreatedBy { get; set; }
        //userattendance 

        public int? UserAttendanceId { get; set; }

        public string? UserAttendanceStatusName { get; set; }



    }
}
