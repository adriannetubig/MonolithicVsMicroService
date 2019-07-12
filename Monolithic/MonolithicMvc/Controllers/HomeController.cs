using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MonolithicMvc.Models;

namespace MonolithicMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Logins()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            return View(login);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
