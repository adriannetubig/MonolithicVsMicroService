using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseBusiness.Interfaces;
using WarehouseData.Interfaces;
using WarehouseEntity;
using WarehouseModel;

namespace WarehouseBusiness.Services
{
    public class BOrderItems : IBOrderItems
    {
        private readonly IDOrderItems _iDOrderItems; 
        public BOrderItems(IDOrderItems iDOrderItems)
        {
            _iDOrderItems = iDOrderItems;
        }

        public async Task Create(OrderItem orderItem, int createdBy)
        {
            await _iDOrderItems.Create(EOrderItem(orderItem), createdBy);
        }

        public async Task<List<OrderItem>> Read()
        {
            var eOrderItems = await _iDOrderItems.Read();
            return OrderItems(eOrderItems);
        }

        public async Task<OrderItem> Read(int orderItemId)
        {
            var eOrderItem = await _iDOrderItems.Read(orderItemId);
            return OrderItem(eOrderItem);
        }

        public async Task Update(OrderItem orderItem, int updatedBy)
        {
            //Make sure that only the OrderItemName is changed
            var eOrderItem = await _iDOrderItems.Read(orderItem.OrderItemId);
            eOrderItem.OrderName = orderItem.OrderName;

            await _iDOrderItems.Update(eOrderItem, updatedBy);
        }

        public async Task Delete(int orderItemId, int deletedBy)
        {
            await _iDOrderItems.Delete(orderItemId, deletedBy);
        }

        private EOrderItem EOrderItem(OrderItem orderItem)
        {
            return new EOrderItem
            {
                CreatedDate = orderItem.CreatedDate,
                UpdatedDate = orderItem.UpdatedDate,

                CreatedBy = orderItem.CreatedBy,
                OrderItemId = orderItem.OrderItemId,
                UpdatedBy = orderItem.UpdatedBy,

                OrderName = orderItem.OrderName,
            };
        }

        private OrderItem OrderItem(EOrderItem eOrderItem)
        {
            return new OrderItem
            {
                CreatedDate = eOrderItem.CreatedDate,
                UpdatedDate = eOrderItem.UpdatedDate,

                CreatedBy = eOrderItem.CreatedBy,
                OrderItemId = eOrderItem.OrderItemId,
                UpdatedBy = eOrderItem.UpdatedBy,

                OrderName = eOrderItem.OrderName,
            };
        }

        private List<OrderItem> OrderItems(List<EOrderItem> eOrderItems)
        {
            return eOrderItems.Select(a => new OrderItem
            {
                CreatedDate = a.CreatedDate,
                UpdatedDate = a.UpdatedDate,

                CreatedBy = a.CreatedBy,
                OrderItemId = a.OrderItemId,
                UpdatedBy = a.UpdatedBy,

                OrderName = a.OrderName,
            }).ToList();
        }
    }
}
