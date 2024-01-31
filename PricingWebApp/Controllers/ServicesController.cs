using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PricingWebApp.Data;
using PricingWebApp.Models;

namespace PricingWebApp.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ServicesTable()
        {

            try
            {
                IEnumerable<Services> services = await _context.Services.ToListAsync();
                return View(services);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { errorMessage = ex.Message });
            }
        }
        [HttpPost, ActionName("_NewService")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewService(Services service)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _context.Services.Add(service);
                    await _context.SaveChangesAsync();
                    TempData["Successaddnewservice"] = "SuccessAddSrvice";
                    return RedirectToAction("ServicesTable");
                }
                else
                {
                    if (service.Title != null) { ViewBag.ServiceName = service.Title; }
                    TempData["Filseaddnewservice"] = "errService";
                    IEnumerable<Services> services = await _context.Services.ToListAsync();
                    return View("ServicesTable", services);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { errorMessage = ex.Message });
            }
        }

        [HttpPost, ActionName("_EditService")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditService(Services service)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Services.Update(service);
                    await _context.SaveChangesAsync();
                    TempData["Successeditservice"] = "SuccessUpdateService";
                    return RedirectToAction("ServicesTable");
                }
                else
                {
                    TempData["Filseeditservice"] = "errUpdateService";
                    IEnumerable<Services> services = await _context.Services.ToListAsync();
                    return View("ServicesTable", services);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { errorMessage = ex.Message });
            }

        }

        [HttpPost, ActionName("_DeleteService")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteService(int? id)
        {
            try
            {
                var service = await _context.Services.FindAsync(id);
                if (service == null)
                {
                    TempData["Filsedeleteservice"] = "errDeleteService";
                    IEnumerable<Services> services = await _context.Services.ToListAsync();
                    return View("ServicesTable", services);
                }
                _context.Remove(service);
                await _context.SaveChangesAsync();
                TempData["Successdeleteservice"] = "SuccessDeleteService";
                return RedirectToAction("ServicesTable");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { errorMessage = ex.Message });
            }
        }
    }
}
