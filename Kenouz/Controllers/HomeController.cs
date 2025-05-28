using Kenouz.Controllers.Helper;
using Kenouz.Models;
using Kenouz.Models.Repositories;
using Kenouz.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kenouz.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClassYearRepo _classYearRepo;
        private readonly CheckCode _checkCode;

        private readonly ITest _test;
        static int test = 0;

        public HomeController(ILogger<HomeController> logger, IClassYearRepo classYearRepo,ITest testt,CheckCode checkCode)
        {
            _logger = logger;
            _classYearRepo = classYearRepo;
            _checkCode = checkCode;

            _test = testt;
            test++;
        }

        public IActionResult Index()
        {
            bool IsAllowed = _checkCode.Check(User.Identity.Name).Result;
            if (IsAllowed)
            {
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("Codes", "Admin");
                }
                else if (User.IsInRole("User1"))
                {
                    ViewData["classYearId"] = _classYearRepo.GetByName("الصف الأول الثانوي").Id;
                    return View();
                }
                else if (User.IsInRole("User2"))
                {
                    ViewData["classYearId"] = _classYearRepo.GetByName("الصف الثاني الثانوي").Id;
                    return View();
                }
                else if (User.IsInRole("User3"))
                {
                    ViewData["classYearId"] = _classYearRepo.GetByName("الصف الثالث الثانوي").Id;
                    return View();
                }
                else
                {
                    return NotFound();
                }
            }
            return NotFound();

        }

       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}