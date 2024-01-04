using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.DTO.Leavetype
{
    public class LeavetypeDto
    {
            public int Id { get; set; }

            public string? Name { get; set; }

            public bool? IsActive { get; set; }

            public bool? IsDeleted { get; set; }

            public DateTime? CreatedOn { get; set; }

            public DateTime? ModifiedOn { get; set; }   
        
    }

}
