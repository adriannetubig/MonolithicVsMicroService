using BaseData;
using Dapper;
using MonolithicMvc.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonolithicMvc.Helper
{
    public class DataService : DBase, IDataService
    {
        public DataService(string connectionString) : base(connectionString) { }

        public async Task LoginsCreate(Login login, int createdBy)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Username", login.Username);
            parameter.Add("@Password", login.Password);
            parameter.Add("@CreatedBy", createdBy);

            await Query(parameter, "[dbo].[LoginCreate]");
        }

        public async Task<List<Login>> LoginsRead()
        {
            DynamicParameters parameter = new DynamicParameters();
            return await QueryList<Login>(parameter, "[dbo].[LoginReadActive]");
        }

        public async Task<Login> LoginsRead(int loginId)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@LoginId", loginId);
            return await QueryModel<Login>(parameter, "[dbo].[LoginRead]");
        }

        public async Task<Login> LoginsRead(string username)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Username", username);
            return await QueryModel<Login>(parameter, "[dbo].[LoginReadByUsername]");
        }

        public async Task LoginsUpdate(Login login, int updatedBy)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@LoginId", login.LoginId);
            parameter.Add("@Password", login.Password);
            parameter.Add("@UpdatedBy", updatedBy);

            await Query(parameter, "[dbo].[LoginUpdate]");
        }

        public async Task LoginsDelete(int loginId, int deletedBy)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@LoginId", loginId); ;
            parameter.Add("@DeletedBy", deletedBy);

            await Query(parameter, "[dbo].[LoginDelete]");
        }

        public async Task InventoryItemsCreate(InventoryItem inventoryItem, int createdBy)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@InventoryName", inventoryItem.InventoryName);
            parameter.Add("@CreatedBy", createdBy);

            await Query(parameter, "[dbo].[InventoryItemCreate]");
        }

        public async Task<List<InventoryItem>> InventoryItemsRead()
        {
            DynamicParameters parameter = new DynamicParameters();
            return await QueryList<InventoryItem>(parameter, "[dbo].[InventoryItemReadAll]");
        }

        public async Task<InventoryItem> InventoryItemsRead(int inventoryItemId)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@InventoryItemId", inventoryItemId);
            return await QueryModel<InventoryItem>(parameter, "[dbo].[InventoryItemRead]");
        }

        public async Task InventoryItemsUpdate(InventoryItem inventoryItem, int updatedBy)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@InventoryItemId", inventoryItem.InventoryItemId);
            parameter.Add("@InventoryName", inventoryItem.InventoryName);
            parameter.Add("@UpdatedBy", updatedBy);

            await Query(parameter, "[dbo].[InventoryItemUpdate]");
        }

        public async Task InventoryItemsDelete(int inventoryItemId, int deletedBy)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@InventoryItemId", inventoryItemId);
            parameter.Add("@DeletedBy", deletedBy);

            await Query(parameter, "[dbo].[InventoryItemDelete]");
        }

        public async Task OrderItemsCreate(OrderItem orderItem, int createdBy)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@OrderName", orderItem.OrderName);
            parameter.Add("@CreatedBy", createdBy);

            await Query(parameter, "[dbo].[OrderItemCreate]");
        }

        public async Task<List<OrderItem>> OrderItemsRead()
        {
            DynamicParameters parameter = new DynamicParameters();
            return await QueryList<OrderItem>(parameter, "[dbo].[OrderItemReadAll]");
        }

        public async Task<OrderItem> OrderItemsRead(int orderItemId)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@OrderItemId", orderItemId);
            return await QueryModel<OrderItem>(parameter, "[dbo].[OrderItemRead]");
        }

        public async Task OrderItemsUpdate(OrderItem orderItem, int updatedBy)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@OrderItemId", orderItem.OrderItemId);
            parameter.Add("@OrderName", orderItem.OrderName);
            parameter.Add("@UpdatedBy", updatedBy);

            await Query(parameter, "[dbo].[OrderItemUpdate]");
        }

        public async Task OrderItemsDelete(int orderItemId, int deletedBy)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@OrderItemId", orderItemId);
            parameter.Add("@DeletedBy", deletedBy);

            await Query(parameter, "[dbo].[OrderItemDelete]");
        }
    }
}
