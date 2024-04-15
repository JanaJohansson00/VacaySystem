using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacaySystem.Data;

namespace VacaySystem.Controllers
{
    public class EmployeeInfoController : Controller
    {
        private readonly VacaySystemDbContext _context;

        public EmployeeInfoController (VacaySystemDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EmployeeApplication()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EmployeeApplication(string? firstName, string? lastName)
        {
            if (firstName == null || lastName == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.FirstName == firstName && m.LastName == lastName);
            if (employee == null)
            {
                return NotFound();
            }


            var vacayApplications = await _context.vacayApplications.Where(va => va.Employee == employee).ToListAsync();
            var hasApplied = vacayApplications.Any();
            
            if (hasApplied)
            {
                //Hämta datum för första ansökan
                var firstApplication = vacayApplications.OrderBy(va => va.ApplicationDate).First();
                var startDate = firstApplication.StartDate;
                var endDate = firstApplication.EndDate;
                var applicationDate = firstApplication.ApplicationDate;

                //Skapa format för datumet
                var formattedStartDate = startDate.ToString("yyyy-mm-dd");
                var formattedEndDate = endDate.ToString("yyyy-mm-dd");
                var formattedApplicationDate = applicationDate.ToString("yyyy-mm-dd");

                
                ViewData["Result"] = $"Employee: {employee.FirstName} {employee.LastName} <br>Period for application: {formattedStartDate} - {formattedEndDate}</br> Application date: {applicationDate}";
            }
            else
            {
                ViewData["Result"] = ($"Employee: {employee.FirstName} {employee.LastName}. <p> No leave applications found.</p>");
            }

            return View();
        }
    }
}
