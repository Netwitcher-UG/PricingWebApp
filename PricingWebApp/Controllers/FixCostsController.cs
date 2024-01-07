using Microsoft.AspNetCore.Mvc;
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
        public IActionResult FixCostsTable()
        {
            try
            {
                //to sort by date
                ViewData["typesIcon"] = "down-up";

                IEnumerable<FixCosts> fixCosts = _context.FixCosts.ToList();
                return View(fixCosts);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { errorMessage = ex.Message });
            }
        }
        //========= search =========
        public IActionResult FixCostsTableSearch(string? values)
        {
            try
            {
            //to sort by date
            ViewData["typesIcon"] = "down-up";

            if (values == null)
            {
                IEnumerable<FixCosts> fixCosts = _context.FixCosts.ToList();
                return View("FixCostsTable", fixCosts);
            }
            ViewData["values"] = values;
            var mytitle = _context.FixCosts.Where(
                i => i.Title.Contains(values)
                ).ToList();
            return View("FixCostsTable", mytitle);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { errorMessage = ex.Message });
            }

        }
        //====== sort by data ===========
        public IActionResult SortByDate(string types)
        {
            try
            {
            if (types == "down-up" || types == "up")
            {
                ViewData["typesIcon"] = "down";
                IEnumerable<FixCosts> fixCosts = _context.FixCosts.OrderByDescending(x => x.Date).ToList();
                return View("FixCostsTable", fixCosts);
            }
            else
            {
                ViewData["typesIcon"] = "up";
                IEnumerable<FixCosts> fixCosts = _context.FixCosts.OrderBy(x => x.Date).ToList();
                return View("FixCostsTable", fixCosts);
            }
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
                ViewBag.FixCostName = fixcost.Title;
                ViewBag.Cost = fixcost.Cost;
                IEnumerable<FixCosts> fixCosts =  _context.FixCosts.ToList();
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
        public IActionResult EditFixCost(int? id)
        {
            try
            {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var fixcost = _context.FixCosts.Find(id);
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
                return PartialView(fixcost);
            }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { errorMessage = ex.Message });
            }

        }
        //============== delete fix cost =============
        [HttpGet, ActionName("_DeleteFixCost")]
        public IActionResult DeleteFixCost(int? id)
        {
            try
            {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var fixcost = _context.FixCosts.Find(id);
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
            var fixcost = _context.FixCosts.Find(id);
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
