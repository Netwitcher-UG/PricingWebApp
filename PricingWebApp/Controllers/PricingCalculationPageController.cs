using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PricingWebApp.Data;
using PricingWebApp.Data.Migrations;
using PricingWebApp.Models;

namespace PricingWebApp.Controllers
{
    public class PricingCalculationPageController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PricingCalculationPageController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult CalculationPage()
        {

            IEnumerable<Employees> employeesModel = _context.Employees.ToList();
            IEnumerable<Services> servicesModel = _context.Services.ToList();

            ViewBag.employeesModel = employeesModel;
            ViewBag.servicesModel = servicesModel;
            return View();
        }


    }
}


