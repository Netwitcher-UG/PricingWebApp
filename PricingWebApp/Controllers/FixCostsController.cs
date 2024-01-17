using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PricingWebApp.Data;
using PricingWebApp.Models;

namespace PricingWebApp.Controllers
{
    public class FixCostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public FixCostsController(ApplicationDbContext context)
        {
            _context = context;
        }
        //=============== fix costs table ============
        public async Task<IActionResult> FixCostsTable()
        {
            ViewData["reopenPopupNew"] = null;
            try
            {
                IEnumerable<FixCosts> fixCosts = await _context.FixCosts.ToListAsync();
                return View(fixCosts);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { errorMessage = ex.Message });
            }
        }


        //=============== new fix cost =============
        [HttpGet, ActionName("_NewFixCost")]
        public IActionResult NewFixCost()
        {

            ViewBag.monthlyCost = 0;
            ViewData["reopenPopupNew"] = null;
            try
            {
                FixCosts fcosts = new();
                return PartialView(fcosts);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { errorMessage = ex.Message });
            }
        }

        [HttpPost, ActionName("_NewFixCost")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewFixCost(FixCosts fixcost)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.FixCosts.Add(fixcost);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("FixCostsTable");
                }
                else
                {
                    ViewData["reopenPopupNew"] = "reopen";
                    if (fixcost.Title != null) { ViewBag.FixCostName = fixcost.Title; }
                    ViewBag.monthlyCost = fixcost.MonthlyCost;
                    IEnumerable<FixCosts> fixCosts = await _context.FixCosts.ToListAsync();
                    return View("FixCostsTable", fixCosts);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { errorMessage = ex.Message });
            }
        }
        //================ edit fix cost  ==============
        [HttpGet, ActionName("_EditFixCost")]
        public async Task<IActionResult> EditFixCost(int? id)
        {

            try
            {
                if (id == null || !_context.FixCosts.Any())
                {
                    return NotFound();
                }
                var fixcost = await _context.FixCosts.FindAsync(id);
                if (fixcost == null)
                {
                    return NotFound();
                }
                return PartialView(fixcost);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { errorMessage = ex.Message });
            }
        }
        [HttpPost, ActionName("_EditFixCost")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFixCost(FixCosts fixcost)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.FixCosts.Update(fixcost);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("FixCostsTable");
                }
                else
                {
                    IEnumerable<FixCosts> fixCosts = await _context.FixCosts.ToListAsync();
                    return View("FixCostsTable", fixCosts);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { errorMessage = ex.Message });
            }

        }
        //============== delete fix cost =============
        [HttpGet, ActionName("_DeleteFixCost")]
        public async Task<IActionResult> DeleteFixCost(int? id)
        {
            try
            {
                if (id == null || !_context.FixCosts.Any())
                {
                    return NotFound();
                }
                var fixcost = await _context.FixCosts.FindAsync(id);
                if (fixcost == null)
                {
                    return NotFound();
                }
                return PartialView(fixcost);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { errorMessage = ex.Message });
            }
        }

        [HttpPost, ActionName("_DeleteFixCost")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                var fixcost = await _context.FixCosts.FindAsync(id);
                if (fixcost == null)
                {
                    return NotFound();
                }
                _context.Remove(fixcost);
                await _context.SaveChangesAsync();
                return RedirectToAction("FixCostsTable");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { errorMessage = ex.Message });
            }
        }
    }
}
