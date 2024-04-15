using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacaySystem.Data;
using VacaySystem.Models;

namespace VacaySystem.Controllers
{
    public class ApplicationInfoController : Controller
    {
        private readonly VacaySystemDbContext _context;

        public ApplicationInfoController(VacaySystemDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("ApplicationsByMonth");
        }

        public IActionResult ApplicationsByMonth()
        {
            return View();
        }



        // GET: LeaveInfo/ApplicationsByMonth
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApplicationsByMonth(int year, int month)
        {
            // Skapa en DateTime-objekt för den första dagen i den angivna månaden
            var startDate = new DateTime(year, month, 1);

            // Skapa en DateTime-objekt för den sista dagen i den angivna månaden
            var endDate = startDate.AddMonths(1).AddDays(-1);

            // Hämta ansökningar för den angivna månaden
            var applications = await _context.vacayApplications
                .Include(va => va.Employee)
                .Where(va => va.StartDate >= startDate && va.EndDate <= endDate)
                .ToListAsync();

            // Skapa en dictionary för att hålla reda på antalet dagar varje person har sökt ledighet
            var vacayApplications = new Dictionary<string, List<(DateTime, DateTime)>>();

            // Loopa igenom varje ansökan och samla in information om ledighetsperioder för varje anställd
            foreach (var application in applications)
            {
                var employeeName = $"{application.Employee.FirstName} {application.Employee.LastName}";
                if (!vacayApplications.ContainsKey(employeeName))
                {
                    vacayApplications[employeeName] = new List<(DateTime, DateTime)>();
                }
                vacayApplications[employeeName].Add((application.StartDate, application.EndDate));
            }

            // Skapa en bool-variabel för att hålla reda på om det finns ansökningar eller inte
            bool hasApplications = vacayApplications.Any();

            // Skicka data till vyn
            ViewData["VacayApplications"] = vacayApplications;
            ViewData["Month"] = startDate.ToString("MMMM yyyy"); // Sätt månadens namn och år
            ViewData["HasApplications"] = hasApplications; // Skicka med bool-variabeln till vyn

            // Sätt de valda månaden och året i ViewBag för att använda dem i formuläret
            ViewBag.SelectedMonth = month;
            ViewBag.SelectedYear = year;

            return View("ApplicationsByMonth");
        }
    }
}

