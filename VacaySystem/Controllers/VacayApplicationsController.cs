using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VacaySystem.Data;
using VacaySystem.Models;

namespace VacaySystem.Controllers
{
    public class VacayApplicationsController : Controller
    {
        private readonly VacaySystemDbContext _context;

        public VacayApplicationsController(VacaySystemDbContext context)
        {
            _context = context;
        }

        // GET: VacayApplications
        public async Task<IActionResult> Index()
        {
            var vacaySystemDbContext = _context.vacayApplications.Include(v => v.Employee);
            return View(await vacaySystemDbContext.ToListAsync());
        }

        // GET: VacayApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacayApplication = await _context.vacayApplications
                .Include(v => v.Employee)
                .FirstOrDefaultAsync(m => m.VacayApplicationId == id);
            if (vacayApplication == null)
            {
                return NotFound();
            }

            return View(vacayApplication);
        }

        // GET: VacayApplications/Create
        public IActionResult Create()
        {
            ViewBag.Employees = _context.Employees.ToList();
            return View();
        }

        // POST: VacayApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VacayApplicationId,StartDate,EndDate,Type,FkEmployeeId")] VacayApplication vacayApplication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacayApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName", vacayApplication.FkEmployeeId);
            return View(vacayApplication);
        }

        // GET: VacayApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacayApplication = await _context.vacayApplications.FindAsync(id);
            if (vacayApplication == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName", vacayApplication.FkEmployeeId);
            return View(vacayApplication);
        }

        // POST: VacayApplications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VacayApplicationId,StartDate,EndDate,ApplicationDate,Type,EmployeeId")] VacayApplication vacayApplication)
        {
            if (id != vacayApplication.VacayApplicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacayApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacayApplicationExists(vacayApplication.VacayApplicationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName", vacayApplication.FkEmployeeId);
            return View(vacayApplication);
        }

        // GET: VacayApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacayApplication = await _context.vacayApplications
                .Include(v => v.Employee)
                .FirstOrDefaultAsync(m => m.VacayApplicationId == id);
            if (vacayApplication == null)
            {
                return NotFound();
            }

            return View(vacayApplication);
        }

        // POST: VacayApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacayApplication = await _context.vacayApplications.FindAsync(id);
            if (vacayApplication != null)
            {
                _context.vacayApplications.Remove(vacayApplication);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacayApplicationExists(int id)
        {
            return _context.vacayApplications.Any(e => e.VacayApplicationId == id);
        }
    }
}
