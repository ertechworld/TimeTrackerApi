using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.DTO.Userattendance
{
    public partial class HourListDto
    {
        public int Id { get; set; }
        public string? StatusName { get; set; }
        public DateTime? CheckoutTime { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? Description { get; set; }
        public bool? ReportGenerated { get; set; }
        public string? Duration { get; set; }
        public string? TaskName { get; set; }
        public string? ExtraHoursDuration { get; set; }      
        public string? ProjectName { get; set; }   
       public string? JobTypeName { get; set; }
        public string? HourlyRate { get; set; }
        public string? WorkingHours { get; set; }

        public bool? IsBreakIncluded { get; set; }
        public DateTime BreakInTime { get; set; }
        public DateTime? BreakOutTime { get; set; }
    }
}



