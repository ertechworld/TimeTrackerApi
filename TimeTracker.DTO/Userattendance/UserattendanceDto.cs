using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.DTO.Userattendance
{
    public class UserattendanceDto
    {
        public int StatusId { get; set; }     

        public string Description { get; set; }

        public int TaskId { get; set; }

        public int? ProjectId { get; set; } 
        public int? JobTypeId { get; set; } 
    }
}
