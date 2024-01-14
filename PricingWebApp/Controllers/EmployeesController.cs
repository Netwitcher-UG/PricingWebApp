using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PricingWebApp.Data;
using PricingWebApp.Data.Migrations;
using PricingWebApp.Models;

namespace PricingWebApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }
        //=============== Employees/Table ============
        public IActionResult EmployeesTable()
        {
            ViewData["reopenPopupNew"] = null;
            try
            {
                IEnumerable<Employees> employees = _context.Employees.ToList();
                return View(employees);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { errorMessage = ex.Message });
            }
        }

        //=============== Employees/Create =============
        [HttpGet]
        public ViewResult NewEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewEmployee(Employees employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("EmployeesTable");
            }
            else
            {
                return View();
            }
        }

        // GET: Employees/Details
        public async Task<IActionResult> DetailsEmployee(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employees = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // GET: Employees/Edit
        public async Task<IActionResult> EditEmployee(int? id)
        {
            if (id == null || _context.Employees == null)
            {
            return NotFound();
            }

            var employees = await _context.Employees.FindAsync(id);
            if (employees == null)
            {
            return NotFound();
            }
            return View(employees);
        }

        // POST: Employees/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEmployee(int id, [Bind("Id,FirstName,MiddleName,LastName,EmailAdress,PhoneNo,Adress")] Employees employees)
        {
            if (id != employees.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeesExists(employees.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(EmployeesTable));
            }
            return View(employees);
        }

        // GET: Employees/Delete
        public async Task<IActionResult> DeleteEmployee(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employees = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // POST: Employees/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Employees'  is null.");
            }
            var employees = await _context.Employees.FindAsync(id);
            if (employees != null)
            {
                _context.Employees.Remove(employees);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(EmployeesTable));
        }

        private bool EmployeesExists(int id)
        {
            return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
