using BaseModel;

namespace WarehouseModel
{
    public class OrderItem : MBase
    {
        public int OrderItemId { get; set; }
        public string OrderName { get; set; }
    }
}
