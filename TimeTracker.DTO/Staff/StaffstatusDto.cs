using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.DTO.Staff
{
    public partial class StaffStatusDto
    {
        public int Id { get; set; }

        public string? Icon { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Css { get; set; }

        public string? Color { get; set; }

        public bool? IsActive { get; set; }

        public int? SortOrder { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string? Code { get; set; }

     
    }
}
