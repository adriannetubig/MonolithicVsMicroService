using BaseData;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseData.Interfaces;
using WarehouseEntity;

namespace WarehouseData.Services
{
    public class DOrderItems : DBase, IDOrderItems
    {
        public DOrderItems(string connectionString) : base(connectionString) { }

        public async Task Create(EOrderItem orderItem, int createdBy)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@OrderName", orderItem.OrderName);
            parameter.Add("@CreatedBy", createdBy);

            await Query(parameter, "[dbo].[OrderItemCreate]");
        }

        public async Task<List<EOrderItem>> Read()
        {
            DynamicParameters parameter = new DynamicParameters();
            return await QueryList<EOrderItem>(parameter, "[dbo].[OrderItemReadAll]");
        }

        public async Task<EOrderItem> Read(int orderItemId)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@OrderItemId", orderItemId);
            return await QueryModel<EOrderItem>(parameter, "[dbo].[OrderItemRead]");
        }

        public async Task Update(EOrderItem orderItem, int updatedBy)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@OrderItemId", orderItem.OrderItemId);
            parameter.Add("@OrderName", orderItem.OrderName);
            parameter.Add("@UpdatedBy", updatedBy);

            await Query(parameter, "[dbo].[OrderItemUpdate]");
        }

        public async Task Delete(int orderItemId, int deletedBy)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@OrderItemId", orderItemId); ;
            parameter.Add("@DeletedBy", deletedBy);

            await Query(parameter, "[dbo].[OrderItemDelete]");
        }
    }
}
