using Microsoft.EntityFrameworkCore;
using TimeTracker.Service.Entities;
using TimeTracker.Service.Models;
using Task = TimeTracker.Service.Models.Task;



namespace TimeTracker.Service.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Status> Status { get; set; }
        public  DbSet<Userattendance> Userattendances { get; set; }
        public  DbSet<Jobtype> Jobtypes { get; set; }
     

        public virtual DbSet<Leavetype> Leavetypes { get; set; }
        public virtual DbSet<Leave> Leaves { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
