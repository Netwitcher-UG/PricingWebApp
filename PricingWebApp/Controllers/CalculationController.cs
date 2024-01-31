using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PricingWebApp.Data;
using PricingWebApp.Models;
using System.Collections.Generic;
using System.Linq;


namespace PricingWebApp.Controllers
{
    public class CalculationController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CalculationController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult CalculationPage()
        {
            try
            {
                //var d = _context.Projects.Select(x => x.PriceCalculation);

                var data =

                  _context.Projects.Join(
                   _context.PriceCalculation,
                   Pro => Pro.Id,
                  Calc => Calc.Project.Id,
                   (Pro, Calc) => new
                   {
                       proId = Pro.Id,
                       proTitle = Pro.Title,
                       ServCost = Calc.ServiceCost,
                       ServId = Calc.Service.Id,
                       empId = Calc.Employee.Id
                   }
                  ).Join(
                   _context.Services,
                   pro => pro.ServId,
                   Services => Services.Id,
                   (Pro, Services) => new
                   {
                       proId = Pro.proId,
                       proTitle = Pro.proTitle,
                       ServCost = Pro.ServCost,
                       servTitle = Services.Title,
                       ServId = Pro.ServId,
                       empId = Pro.empId
                   }
                   ).Join(
                   _context.Employees,
                   pro => pro.empId,
                   Employees => Employees.Id,
                   (Pro, Employees) => new
                   {
                       proId = Pro.proId,
                       proTitle = Pro.proTitle,
                       ServCost = Pro.ServCost,
                       servTitle = Pro.servTitle,
                       ServId = Pro.ServId,
                       empName = Employees.FirstName

                   }
                   ).ToList();




                IEnumerable<PriceCalculation> data1 = _context.PriceCalculation.Include(e => e.Employee)
                    .Include(s => s.Service)
                    .Include(p => p.Project);

                IEnumerable<IGrouping<int, PriceCalculation>> groupCalculation = data1.GroupBy(x => x.Project.Id);


                return View(groupCalculation);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { errorMessage = ex.Message });
            }

        }
    }
}
