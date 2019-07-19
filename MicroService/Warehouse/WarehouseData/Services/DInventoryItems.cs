using BaseData;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseData.Interfaces;
using WarehouseEntity;

namespace WarehouseData.Services
{
    public class DInventoryItems : DBase, IDInventoryItems
    {
        public DInventoryItems(string connectionString) : base(connectionString) { }

        public async Task Create(EInventoryItem inventoryItem, int createdBy)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@InventoryName", inventoryItem.InventoryName);
            parameter.Add("@CreatedBy", createdBy);

            await Query(parameter, "[dbo].[InventoryItemCreate]");
        }

        public async Task<List<EInventoryItem>> Read()
        {
            DynamicParameters parameter = new DynamicParameters();
            return await QueryList<EInventoryItem>(parameter, "[dbo].[InventoryItemReadAll]");
        }

        public async Task<EInventoryItem> Read(int inventoryItemId)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@InventoryItemId", inventoryItemId);
            return await QueryModel<EInventoryItem>(parameter, "[dbo].[InventoryItemRead]");
        }

        public async Task Update(EInventoryItem inventoryItem, int updatedBy)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@InventoryItemId", inventoryItem.InventoryItemId);
            parameter.Add("@InventoryName", inventoryItem.InventoryName);
            parameter.Add("@UpdatedBy", updatedBy);

            await Query(parameter, "[dbo].[InventoryItemUpdate]");
        }

        public async Task Delete(int inventoryItemId, int deletedBy)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@InventoryItemId", inventoryItemId); ;
            parameter.Add("@DeletedBy", deletedBy);

            await Query(parameter, "[dbo].[InventoryItemDelete]");
        }
    }
}
