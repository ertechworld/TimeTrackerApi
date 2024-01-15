using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.Userattendance;

namespace TimeTracker.Service.Entities
{
    public partial class Employee
    {
        //public Employee() {
        //    Userattendances= new HashSet<Userattendance>();
        //}
        public int Id { get; set; }

        public string? Login { get; set; }

        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

        public string? Description { get; set; }

        public int? RoleId { get; set; }

        public bool? Approved { get; set; }
      

        public bool? IsActive { get; set; }

        public bool? AutoRefresh { get; set; }

        public string? Notes { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string? ForgetPwd { get; set; }

        public string? PhoneNumber { get; set; }

 
        public string? UploadedFiles { get; set; }

        public string? Color { get; set; }

        public int? SerialNumber { get; set; }

        public int? DisplayNumber { get; set; }

        public string? FilePath { get; set; }

        public int? CreatedBy { get; set; }

        public virtual Userattendance? UserAttendances { get;set; }
    }
}
