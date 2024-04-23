using BLL.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISchedulesService _schedulesService;

        public HomeController(ILogger<HomeController> logger, ISchedulesService schedulesService)
        {
            _logger = logger;
            _schedulesService = schedulesService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View(_schedulesService.SchedulesWithDisciplineGetAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Privacy", "Home");
            else
                return View();
        }

 
        [AllowAnonymous]
        [HttpGet("/Account/Login")]
        public IActionResult AccessDeniedLogin()
        {
            return RedirectToAction("Login", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}