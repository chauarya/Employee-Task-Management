using Microsoft.EntityFrameworkCore;


namespace EmployeeTaskManagement.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }

    }
}
