using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Service.Entities
{
    public partial class Break
    {
        public int Id { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? BreakInTime { get; set; }

        public DateTime? BreakOutTime { get; set; }

        public string? BreakDuration { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? UserAttendanceId { get; set; }

        public virtual Userattendance? UserAttendance { get; set; }
    }
}
