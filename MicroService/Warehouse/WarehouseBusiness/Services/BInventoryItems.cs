using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseBusiness.Interfaces;
using WarehouseData.Interfaces;
using WarehouseEntity;
using WarehouseModel;

namespace WarehouseBusiness.Services
{
    public class BInventoryItems : IBInventoryItems
    {
        private readonly IDInventoryItems _iDInventoryItems; 
        public BInventoryItems(IDInventoryItems iDInventoryItems)
        {
            _iDInventoryItems = iDInventoryItems;
        }

        public async Task Create(InventoryItem inventoryItem, int createdBy)
        {
            await _iDInventoryItems.Create(EInventoryItem(inventoryItem), createdBy);
        }

        public async Task<List<InventoryItem>> Read()
        {
            var eInventoryItems = await _iDInventoryItems.Read();
            return InventoryItems(eInventoryItems);
        }

        public async Task<InventoryItem> Read(int inventoryItemId)
        {
            var eInventoryItem = await _iDInventoryItems.Read(inventoryItemId);
            return InventoryItem(eInventoryItem);
        }

        public async Task Update(InventoryItem inventoryItem, int updatedBy)
        {
            //Make sure that only the InventoryItemName is changed
            var eInventoryItem = await _iDInventoryItems.Read(inventoryItem.InventoryItemId);
            eInventoryItem.InventoryName = inventoryItem.InventoryName;

            await _iDInventoryItems.Update(eInventoryItem, updatedBy);
        }

        public async Task Delete(int inventoryItemId, int deletedBy)
        {
            await _iDInventoryItems.Delete(inventoryItemId, deletedBy);
        }

        private EInventoryItem EInventoryItem(InventoryItem inventoryItem)
        {
            return new EInventoryItem
            {
                CreatedDate = inventoryItem.CreatedDate,
                UpdatedDate = inventoryItem.UpdatedDate,

                CreatedBy = inventoryItem.CreatedBy,
                InventoryItemId = inventoryItem.InventoryItemId,
                UpdatedBy = inventoryItem.UpdatedBy,

                InventoryName = inventoryItem.InventoryName,
            };
        }

        private InventoryItem InventoryItem(EInventoryItem eInventoryItem)
        {
            return new InventoryItem
            {
                CreatedDate = eInventoryItem.CreatedDate,
                UpdatedDate = eInventoryItem.UpdatedDate,

                CreatedBy = eInventoryItem.CreatedBy,
                InventoryItemId = eInventoryItem.InventoryItemId,
                UpdatedBy = eInventoryItem.UpdatedBy,

                InventoryName = eInventoryItem.InventoryName,
            };
        }

        private List<InventoryItem> InventoryItems(List<EInventoryItem> eInventoryItems)
        {
            return eInventoryItems.Select(a => new InventoryItem
            {
                CreatedDate = a.CreatedDate,
                UpdatedDate = a.UpdatedDate,

                CreatedBy = a.CreatedBy,
                InventoryItemId = a.InventoryItemId,
                UpdatedBy = a.UpdatedBy,

                InventoryName = a.InventoryName,
            }).ToList();
        }
    }
}
