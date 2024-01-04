using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Service.Entities
{
    public  class Leave
    {
        public int Id { get; set; }

        public string? ReasonForLeave { get; set; }

        public int? UserId { get; set; }

        public int? LeaveTypeId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool? IsDeleted { get; set; }
      
        public virtual Leavetype? LeaveType { get; set; }

    }
}
