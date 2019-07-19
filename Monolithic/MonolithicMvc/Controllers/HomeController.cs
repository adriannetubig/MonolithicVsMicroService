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

        [HttpGet("Logins")]
        public async Task<IActionResult> Logins()
        {
            var logins = await _iDataService.LoginsRead();
            return View(logins);
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

        [HttpGet("InventoryItemsCreate")]
        public IActionResult InventoryItemsCreate()
        {
            var inventoryItem = new InventoryItem();
            return View(inventoryItem);
        }

        [HttpPost("InventoryItemsCreate")]
        public async Task<IActionResult> InventoryItemsCreate(InventoryItem inventoryItem)
        {
            await _iDataService.InventoryItemsCreate(inventoryItem, LoginId);
            return RedirectToAction("InventoryItems");
        }

        [HttpGet("InventoryItems")]
        public async Task<IActionResult> InventoryItems()
        {
            var inventoryItems = await _iDataService.InventoryItemsRead();
            return View(inventoryItems);
        }

        [HttpGet("InventoryItemsUpdate/{inventoryItemId}")]
        public async Task<IActionResult> InventoryItemsUpdate(int inventoryItemId)
        {
            var inventoryItem = await _iDataService.InventoryItemsRead(inventoryItemId);
            return View(inventoryItem);
        }

        [HttpPost("InventoryItemsUpdate")]
        public async Task<IActionResult> InventoryItemsUpdate(InventoryItem inventoryItem)
        {
            var eInventoryItem = await _iDataService.InventoryItemsRead(inventoryItem.InventoryItemId);
            eInventoryItem.InventoryName = inventoryItem.InventoryName;
            await _iDataService.InventoryItemsUpdate(eInventoryItem, LoginId);
            return RedirectToAction("InventoryItems");
        }

        [HttpGet("InventoryItemsDelete/{inventoryItemId}")]
        public async Task<IActionResult> InventoryItemsDelete(int inventoryItemId)
        {
            await _iDataService.InventoryItemsDelete(inventoryItemId, LoginId);
            return RedirectToAction("InventoryItems");
        }

        [HttpGet("OrderItemsCreate")]
        public IActionResult OrderItemsCreate()
        {
            var orderItem = new OrderItem();
            return View(orderItem);
        }

        [HttpPost("OrderItemsCreate")]
        public async Task<IActionResult> OrderItemsCreate(OrderItem orderItem)
        {
            await _iDataService.OrderItemsCreate(orderItem, LoginId);
            return RedirectToAction("OrderItems");
        }

        [HttpGet("OrderItems")]
        public async Task<IActionResult> OrderItems()
        {
            var orderItems = await _iDataService.OrderItemsRead();
            return View(orderItems);
        }

        [HttpGet("OrderItemsUpdate/{orderItemId}")]
        public async Task<IActionResult> OrderItemsUpdate(int orderItemId)
        {
            var orderItem = await _iDataService.OrderItemsRead(orderItemId);
            return View(orderItem);
        }

        [HttpPost("OrderItemsUpdate")]
        public async Task<IActionResult> OrderItemsUpdate(OrderItem orderItem)
        {
            var eOrderItem = await _iDataService.OrderItemsRead(orderItem.OrderItemId);
            eOrderItem.OrderName = orderItem.OrderName;
            await _iDataService.OrderItemsUpdate(eOrderItem, LoginId);
            return RedirectToAction("OrderItems");
        }

        [HttpGet("OrderItemsDelete/{orderItemId}")]
        public async Task<IActionResult> OrderItemsDelete(int orderItemId)
        {
            await _iDataService.OrderItemsDelete(orderItemId, LoginId);
            return RedirectToAction("OrderItems");
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
