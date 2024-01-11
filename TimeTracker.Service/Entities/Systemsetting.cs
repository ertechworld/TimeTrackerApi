using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Service.Entities
{
    public  class Systemsetting
    {
        public int Id { get; set; }
        public string? IpAddress { get; set; }
       public int? TenantId { get; set; }
        public bool? IsActive { get; set; }
        public virtual Tenant? Tenant { get; set; }
    }
}
