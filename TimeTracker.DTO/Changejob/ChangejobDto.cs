using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.Status;

namespace TimeTracker.DTO.ChangejobDto
{
    public class ChangejobDto
    {

        public string Description { get; set; }
        public int? TaskId { get; set; }
       // public string TaskName { get; set; }
        public int? ProjectId { get; set; }
       // public string ProjectName { get; set; }
        public int? JobTypeId { get; set; }
      //  public string JobTypeName { get; set; }
    }

}
