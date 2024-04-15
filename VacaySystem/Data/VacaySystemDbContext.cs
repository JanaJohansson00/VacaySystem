using Microsoft.EntityFrameworkCore;
using VacaySystem.Models;

namespace VacaySystem.Data
{
    public class VacaySystemDbContext : DbContext
    {
        public VacaySystemDbContext(DbContextOptions<VacaySystemDbContext> options)
            : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<VacayApplication> vacayApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
               .HasMany(e => e.VacayApplications)
               .WithOne(va => va.Employee)
               .HasForeignKey(va => va.FkEmployeeId);

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 8, FirstName = "Nour", LastName = "Wilson" },
                new Employee { EmployeeId = 9, FirstName = "Liza", LastName = "Folson" }
            );
            modelBuilder.Entity<VacayApplication>().HasData(
                new VacayApplication { VacayApplicationId = 3, StartDate = new DateTime(24, 07, 15), EndDate = new DateTime(24, 08, 01), Type = LeaveType.Holiday, FkEmployeeId = 3 },
                new VacayApplication { VacayApplicationId = 4, StartDate = new DateTime(24, 06, 15), EndDate = new DateTime(24, 06, 20), Type = LeaveType.Holiday, FkEmployeeId = 2 }
            ); 
        }

        
    }
}  
