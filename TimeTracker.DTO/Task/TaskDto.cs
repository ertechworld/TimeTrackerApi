using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.DTO.Task
{
    public class TaskRequestDto
    {
        [Required(ErrorMessage = "Vinarliga skriva navn")]
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }

        [Required(ErrorMessage = "Vinarliga skriva navn")]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
    public class TaskResponseDto: TaskRequestDto
    {
        public int Id { get; set; }
        
    }
}
