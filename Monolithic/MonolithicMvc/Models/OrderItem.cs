using BaseEntity;

namespace MonolithicMvc.Models
{
    public class OrderItem : EBase
    {
        public int OrderItemId { get; set; }
        public string OrderName { get; set; }
    }
}