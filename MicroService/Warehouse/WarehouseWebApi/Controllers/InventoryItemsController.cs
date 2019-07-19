using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarehouseBusiness.Interfaces;
using WarehouseModel;

namespace WarehouseWebApi.Controllers
{
    public class InventoryItemsController : BaseController
    {
        private readonly IBInventoryItems _iBInventoryItems;

        public InventoryItemsController(IBInventoryItems iBInventoryItems)
        {
            _iBInventoryItems = iBInventoryItems;
        }

        [HttpPut, Route("")]
        public async Task<IActionResult> Create([FromBody]InventoryItem inventoryItem)
        {
            await _iBInventoryItems.Create(inventoryItem, LoginId);
            return StatusCode(201);
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> Read()
        {
            var inventories = await _iBInventoryItems.Read();
            return Ok(inventories);
        }

        [HttpGet, Route("{inventoryItemId}")]
        public async Task<IActionResult> Read(int inventoryItemId)
        {
            var inventoryItem = await _iBInventoryItems.Read(inventoryItemId);
            return Ok(inventoryItem);
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> Update([FromBody]InventoryItem inventoryItem)
        {
            await _iBInventoryItems.Update(inventoryItem, LoginId);
            return Ok();
        }

        [HttpDelete, Route("{inventoryItemId}")]
        public async Task<IActionResult> Delete(int inventoryItemId)
        {
            await _iBInventoryItems.Delete(inventoryItemId, LoginId);
            return NoContent();
        }
    }
}
