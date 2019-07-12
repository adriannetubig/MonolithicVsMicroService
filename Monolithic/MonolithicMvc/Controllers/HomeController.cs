using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonolithicMvc.Helper;
using MonolithicMvc.Models;

namespace MonolithicMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataService _iDataService;
        public HomeController(IDataService iDataService)
        {
            _iDataService = iDataService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginCreate(Login login)
        {
            login.Password = BCrypt.Net.BCrypt.HashPassword(login.Password);
            _iDataService.Create(login, LoginId);
            return View(login);
        }


        [HttpGet]
        public IActionResult Login()
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

        private int LoginId
        {
            get
            {
                var loginId = HttpContext.Session.GetInt32("LoginId");
                return loginId ?? 0;
            }
            set
            {
                HttpContext.Session.SetInt32("LoginId", value);
            }
        }
    }
}
