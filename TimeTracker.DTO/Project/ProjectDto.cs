using System.ComponentModel.DataAnnotations;
using TimeTracker.DTO.Task;

namespace TimeTracker.DTO.Product
{
    public class ProjectRequestDto
    {
     
        [Required(ErrorMessage = "Vinarliga skriva navn")]
        public string Name { get; set; } = string.Empty;
       
        public string Description { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required(ErrorMessage = "Vinarliga skriva navn")]
        public int? TenantId { get; set; }
    }
    public class ProjectResponseDto : ProjectRequestDto
    {
        public int Id { get; set; }

    }
}
