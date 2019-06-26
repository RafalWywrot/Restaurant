namespace Restaurant.Domain.DTO
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public OrderDTO OrderParent { get; set; }
        public MenuDTO Menu { get; set; }
        public int Quantity { get; set; }
    }
}
