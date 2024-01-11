using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = TimeTracker.Service.Entities.Task;

namespace TimeTracker.Service.Entities
{
    public  class Userattendance
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CheckoutTime { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsActive { get; set; }
        public string? Description { get; set; }
        public bool? ReportGenerated { get; set; }
        public string? Duration { get; set; }
        public int? TaskId { get; set; }
        public string? ExtraHoursDuration { get; set; }
        public int? ProjectId { get; set; }
        public bool? IsLogOut { get; set; }
        public int? JobTypeId { get; set; }
        public virtual Jobtype? JobType { get; set; }
        public virtual Project? Project { get; set; }
        public  Status? Status { get; set; }
        public Task? Task { get; set; }
        public  User? User { get; set; }
        public  Break? Break { get; set; }
    }

}
