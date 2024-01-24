//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using PricingWebApp.Models;

//namespace PricingWebApp.Controllers
//{
//    public class AdminController : Controller
//    {
//        private readonly RoleManager<IdentityRole> _roleManager;

//        public AdminController(RoleManager<IdentityRole> roleManager)
//        {
//            _roleManager = roleManager;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(IdentityRole role)
//        {
//            if (ModelState.IsValid)
//            {
//                // Check if the role already exists
//                var roleExist = await _roleManager.RoleExistsAsync(role);

//                if (!roleExist)
//                {
//                    // Create the role
//                    var result = await _roleManager.CreateAsync(new IdentityRole(role));

//                    if (result.Succeeded)
//                    {
//                        // Role created successfully
//                        return RedirectToAction("Index");
//                    }
//                    else
//                    {
//                        // Handle errors if role creation fails
//                        foreach (var error in result.Errors)
//                        {
//                            ModelState.AddModelError("", error.Description);
//                        }
//                    }
//                }
//                else
//                {
//                    ModelState.AddModelError("", "Role already exists");
//                }
//            }

//            // If we reach here, something went wrong, return to the Create view with the model
//            return View(role);
//        }
//    }
//}
