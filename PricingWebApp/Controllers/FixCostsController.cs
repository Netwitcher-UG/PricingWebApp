using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> FixCostsTable()
        {
            
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
                    TempData["Successaddnewfixcost"] = "Success";
                    return RedirectToAction("FixCostsTable");
                }
                else
                {
                   
                    if (fixcost.Title != null) { ViewBag.FixCostName = fixcost.Title; }
                    ViewBag.monthlyCost = fixcost.MonthlyCost;
                    TempData["Filseaddnewfixcost"] = "err";
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
                    TempData["Successeditfixcost"] = "Success";
                    return RedirectToAction("FixCostsTable");
                }
                else
                {
                    TempData["Filseditfixcost"] = "err";
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
    

        [HttpPost, ActionName("_DeleteFixCost")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                var fixcost = await _context.FixCosts.FindAsync(id);
                if (fixcost == null)
                {
                    TempData["Filsdeletefixcost"] = "err";
                    IEnumerable<FixCosts> fixCosts = await _context.FixCosts.ToListAsync();
                    return View("FixCostsTable", fixCosts);
                }
                _context.Remove(fixcost);
                await _context.SaveChangesAsync();
                TempData["Successdeletefixcost"] = "Success";
                return RedirectToAction("FixCostsTable");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { errorMessage = ex.Message });
            }
        }
    }
}
