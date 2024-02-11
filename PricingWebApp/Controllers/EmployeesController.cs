using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PricingWebApp.Data;
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
      //  [Authorize(Roles = "Admin")]
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
        

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> NewEmployee(Employees employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                TempData["SuccessaddnewEmployee"] = "success";
                return RedirectToAction("EmployeesTable");
            }
            else
            {
                TempData["FilseaddnewEmployee"] = "err";
                IEnumerable<Employees> employees = _context.Employees.ToList();
                return View("EmployeesTable", employees);
            }
        }

        

        //============ Employees/Edit ===========
        [HttpPost, ActionName("EditEmployee")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFixCost(int? id, Employees employees)
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
                    TempData["SuccesseditEmployee"] = "success";
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
            TempData["FilseditEmployee"] = "err";
            return View(employees);
        }

        // =========== Employees/Delete ===========
        [HttpPost, ActionName("DeleteEmployee")]
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
            TempData["SuccessdeleteEmployee"] = "success";
            return RedirectToAction(nameof(EmployeesTable));
        }

        private bool EmployeesExists(int id)
        {
            return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
