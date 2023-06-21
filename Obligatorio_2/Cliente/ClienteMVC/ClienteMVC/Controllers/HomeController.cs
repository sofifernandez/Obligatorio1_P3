using Microsoft.AspNetCore.Mvc;
using ClienteMVC.Models;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace ClienteMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("email") != null)
            {
                ViewBag.Usuario = HttpContext.Session.GetString("email");
                return View();
            }
            else 
            {
                return Redirect("/Usuario/Login");
            }
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