using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Service.Models;

namespace TimeTracker.Service.Entities
{
    public partial class Userattendance
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? StatusId { get; set; }

        public DateTime? CheckoutTime { get; set; }

        public DateTime? CreatedOn { get; set; }

        public bool? IsActive { get; set; }

        public string? Description { get; set; }

        
        public int? TaskId { get; set; }
        public int? JobTypeId { get; set; }

        public int? ProjectId { get; set; }

      

     
    }

}
