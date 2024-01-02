using Microsoft.EntityFrameworkCore;
using TimeTracker.Service.Models;
using Task = TimeTracker.Service.Models.Task;



namespace TimeTracker.Service.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
