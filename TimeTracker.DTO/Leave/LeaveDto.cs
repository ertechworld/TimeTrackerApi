using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.Task;

namespace TimeTracker.DTO.Leave
{
    public class LeaveRequestDto
    {
        public string? ReasonForLeave { get; set; }
        public int? UserId { get; set; }
        public int? LeaveTypeId { get; set; }
        public string? LeaveTypeName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
    public class LeaveResponseDto : LeaveRequestDto
    {
       public int Id { get; set; }

    }
}
