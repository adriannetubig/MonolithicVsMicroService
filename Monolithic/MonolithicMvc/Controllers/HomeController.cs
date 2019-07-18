using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MonolithicMvc.Helper;
using MonolithicMvc.Models;

namespace MonolithicMvc.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly IDataService _iDataService;
        public HomeController(IDataService iDataService)
        {
            _iDataService = iDataService;
        }


        [HttpGet("")]
        public IActionResult Login()
        {
            var login = new Login();
            return View(login);
        }

        [HttpPost("")]
        public async Task<IActionResult> Login(Login login)
        {
            var eLogin = await _iDataService.LoginsRead(login.Username);
            if (BCrypt.Net.BCrypt.Verify(login.Password, eLogin.Password))
                LoginId = eLogin.LoginId;
            return View(login);
        }

        [HttpGet("LoginsCreate")]
        public IActionResult LoginsCreate()
        {
            var login = new Login();
            return View(login);
        }

        [HttpPost("LoginsCreate")]
        public async Task<IActionResult> LoginsCreate(Login login)
        {
            login.Password = BCrypt.Net.BCrypt.HashPassword(login.Password);
            await _iDataService.LoginsCreate(login, LoginId);
            return RedirectToAction("Logins");
        }

        [HttpGet("LoginsUpdate/{loginId}")]
        public async Task<IActionResult> LoginsUpdate(int loginId)
        {
            var login = await _iDataService.LoginsRead(loginId);
            return View(login);
        }

        [HttpPost("LoginsUpdate")]
        public async Task<IActionResult> LoginsUpdate(Login login)
        {
            var eLogin = await _iDataService.LoginsRead(login.LoginId);
            eLogin.Password = BCrypt.Net.BCrypt.HashPassword(login.Password);
            await _iDataService.LoginsUpdate(eLogin, LoginId);
            return RedirectToAction("Logins");
        }


        [HttpGet("LoginsDelete/{loginId}")]
        public async Task<IActionResult> LoginsDelete(int loginId)
        {
            await _iDataService.LoginsDelete(loginId, LoginId);
            return RedirectToAction("Logins");
        }

        [HttpGet("Logins")]
        public async Task<IActionResult> Logins()
        {
            var logins = await _iDataService.LoginsRead();
            return View(logins);
        }

        private int LoginId
        {
            get
            {
                return 0;
            }
            set
            {
                //HttpContext.Session.SetInt32("LoginId", value); //add code for session
            }
        }
    }
}
