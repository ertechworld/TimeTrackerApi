using Microsoft.EntityFrameworkCore;
using TimeTracker.Service.Models;

namespace TimeTracker.Service.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }
        public DbSet<User> Users { get; set; }  
        public DbSet<Product> Products { get; set; }
    }
}
