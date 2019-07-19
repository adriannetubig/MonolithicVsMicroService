using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarehouseBusiness.Interfaces;
using WarehouseModel;

namespace WarehouseWebApi.Controllers
{
    public class OrderItemsController : BaseController
    {
        private readonly IBOrderItems _iBOrderItems;

        public OrderItemsController(IBOrderItems iBOrderItems)
        {
            _iBOrderItems = iBOrderItems;
        }

        [HttpPut, Route("")]
        public async Task<IActionResult> Create([FromBody]OrderItem orderItem)
        {
            await _iBOrderItems.Create(orderItem, LoginId);
            return StatusCode(201);
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> Read()
        {
            var orderItems = await _iBOrderItems.Read();
            return Ok(orderItems);
        }

        [HttpGet, Route("{orderItemId}")]
        public async Task<IActionResult> Read(int orderItemId)
        {
            var orderItem = await _iBOrderItems.Read(orderItemId);
            return Ok(orderItem);
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> Update([FromBody]OrderItem orderItem)
        {
            await _iBOrderItems.Update(orderItem, LoginId);
            return Ok();
        }

        [HttpDelete, Route("{orderItemId}")]
        public async Task<IActionResult> Delete(int orderItemId)
        {
            await _iBOrderItems.Delete(orderItemId, LoginId);
            return NoContent();
        }
    }
}
