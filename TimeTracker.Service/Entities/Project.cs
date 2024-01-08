using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Service.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Priority { get; set; }
        public int? CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public int? DeletedBy { get; set; }
        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
        public int? TenantId { get; set; }
     
    }
}
