using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Service.Entities
{
    public  class JobtypeDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public bool? IsActive { get; set; }
       
        public int? TenantId { get; set; }

      
    }
}
