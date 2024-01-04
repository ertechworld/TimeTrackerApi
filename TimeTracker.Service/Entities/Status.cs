using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Service.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Color { get; set; } = null!;
        public bool? IsDeleted { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

    }
}
