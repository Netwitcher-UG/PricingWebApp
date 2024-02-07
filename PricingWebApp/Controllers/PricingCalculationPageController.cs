using Microsoft.AspNetCore.Mvc;
using PricingWebApp.Data;
using PricingWebApp.Models;
using static PricingWebApp.Controllers.PricingCalculationPageController;

namespace PricingWebApp.Controllers
{
    public class PricingCalculationPageController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PricingCalculationPageController(ApplicationDbContext context)
        {
            _context = context;
        }
        public class MyServicesRows
        {
            public int Id { get; set; }
            public bool IsChecked { get; set; } = false;
            public double ServiceRate { get; set; }
            public int ServiceCount { get; set; }
        }
        public class MyEmployeesRows
        {
            public int Id { get; set; } = 0;
            public bool IsChecked { get; set; } = false;
            public int EmployeeCount { get; set; } = 1;
        }

        public class MyPagesModels
        {
            public List<Employees>? EmployeesModel { get; set; }
            public List<Services>? MyServicesModel { get; set; }
            [BindProperty]
            public List<MyServicesRows>? MyServicesRows { get; set; }
            [BindProperty]
            public List<MyEmployeesRows>? MyEmployeesRows { get; set; }
            [BindProperty]
            public string? MyTitle { get; set; }
            [BindProperty]
            public int ProfitRatio { get; set; }
            [BindProperty]
            public int Discount { get; set; }
        }
        public MyPagesModels CalculationPageData()
        {
            List<Employees> employees = _context.Employees.ToList();
            List<Services> services = _context.Services.ToList();
            List<MyServicesRows> mySerListRows = new();
            for (int i = 0; i < services.Count; i++)
            {
                mySerListRows.Add(new MyServicesRows());
            }
            List<MyEmployeesRows> myEmpListRows = new();
            for (int i = 0; i < employees.Count; i++)
            {
                myEmpListRows.Add(new MyEmployeesRows());
            }
            MyPagesModels myModel = new()
            {
                EmployeesModel = employees,
                MyServicesModel = services,
                MyServicesRows = mySerListRows,
                MyEmployeesRows = myEmpListRows
            };
            return myModel;
        }
        [HttpGet]
        public IActionResult CalculationPage()
        {
            ViewData["ProfitRatio"] = 50;
            ViewData["Discount"] = 15;
            return View(CalculationPageData());
        }
        [HttpPost]
        public IActionResult CalculationPage(MyPagesModels myServicesRowsModel)
        { 
            if(myServicesRowsModel.MyEmployeesRows != null && myServicesRowsModel.MyServicesRows != null)
            { 
                List<Employees> myEmployees = _context.Employees.ToList();
                List<MyEmployeesRows>? MyEmployeesRows = myServicesRowsModel.MyEmployeesRows;
                List<MyServicesRows>? MyServicesRows = myServicesRowsModel.MyServicesRows;
                List<double> fixCosts = _context.FixCosts.Select(x => x.MonthlyCost).ToList();
                string? MyTitle = myServicesRowsModel.MyTitle;
                int ProfitRatio = myServicesRowsModel.ProfitRatio;
                int Discount = myServicesRowsModel.Discount;
                Calculator calculator = new(myEmployees, MyEmployeesRows, MyServicesRows, fixCosts,
                     ProfitRatio, Discount);
                double result = calculator.PriceCalculation(out double package2, out double package3);
                ViewBag.package1 = Math.Round(result, 2) + "€";
                ViewBag.package2 = Math.Round(package2, 2) + "€";
                ViewBag.package3 = Math.Round(package3, 2) + "€";
                ViewData["ProfitRatio"] = ProfitRatio;
                ViewData["Discount"] = Discount;
                return View("CalculationPage", CalculationPageData());
            }
            else
            {
                return View("CalculationPage", CalculationPageData());
            }
        }

    }
    public class Calculator
    {
        private readonly List<Employees> _myEmployees;
        private readonly List<MyEmployeesRows> _employeeCalculator;
        private readonly List<MyServicesRows> _serviceCalculator;
        private readonly List<double> _fixcostsMonthlyCost;
        private readonly double _profitRatio;
        private readonly double _Discount;
        public Calculator(List<Employees> myEmployees, List<MyEmployeesRows> employeeCalculator, List<MyServicesRows> serviceCalculator,
            List<double> fixcostsMonthlyCost, double profitRatio, double Discount)
        {
            _myEmployees = myEmployees;
            _employeeCalculator = employeeCalculator;
            _serviceCalculator = serviceCalculator;
            _fixcostsMonthlyCost = fixcostsMonthlyCost;
            _profitRatio = profitRatio;
            _Discount = Discount;
        }
        public double PriceCalculation(out double package2, out double package3)
        {
            List<double> myEmployeesFields = new();
            foreach(MyEmployeesRows myEmployeesRow in _employeeCalculator)
            {
                if (myEmployeesRow.IsChecked)
                {
                    double EmployeeHourRate = _myEmployees.Where(x => x.Id == myEmployeesRow.Id).First().HourRate;
                    double EmployeesSum = EmployeeHourRate * myEmployeesRow.EmployeeCount;
                    myEmployeesFields.Add(EmployeesSum);

                }
            }
            List<double> myServicesFields = new();
            foreach (MyServicesRows myServicesRow in _serviceCalculator)
            {
                if (myServicesRow.IsChecked)
                {
                    double ServicesSum = myServicesRow.ServiceRate * myServicesRow.ServiceCount;
                    myServicesFields.Add(ServicesSum);
                }
            }

            double EmployeeSums = myEmployeesFields.Sum();
            double ServicesSums = myServicesFields.Sum();
            double FXMonthlyCost = _fixcostsMonthlyCost.Sum();
            double TotalCosts = EmployeeSums + ServicesSums + FXMonthlyCost;
            double profRat = TotalCosts * _profitRatio / 100;
            double lastPrice = TotalCosts + profRat;
            package2 = lastPrice - (lastPrice * _Discount / 100);
            package3 = package2 - (package2 * _Discount / 100);
            return lastPrice;
        }
    }
}


