using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.Status;

namespace TimeTracker.DTO.Userattendance
{
    public class UserattendanceDto
    {
        public int Id { get; set; }
       // public string? StatusName { get; set; }
        public int StatusId { get; set; }
        public int UserId { get; set; }
        public string? Duration { get; set; }

        public string Description { get; set; }

        public int TaskId { get; set; }
        public DateTime? CheckoutTime { get; set; }
        public DateTime? CreatedOn { get; set; }

        public int? ProjectId { get; set; } 
        public int? JobTypeId { get; set; } 
       // public Status Status { get; set; }
    }
}
