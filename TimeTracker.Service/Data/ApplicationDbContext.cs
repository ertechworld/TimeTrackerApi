using Microsoft.EntityFrameworkCore;
using TimeTracker.Service.Entities;
using Task = TimeTracker.Service.Entities.Task;


namespace TimeTracker.Service.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Userattendance> UserAttendances { get; set; }
        public DbSet<Jobtype> JobTypes { get; set; }
        public virtual DbSet<Leavetype> LeaveTypes { get; set; }
        public virtual DbSet<Leave> Leaves { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Break> Breaks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Staffstatus> Staffstatus { get; set; } 
        public DbSet<Systemsetting> SystemSettings { get; set; }
        public  DbSet<Tenant> Tenants { get; set; }
    }
}

