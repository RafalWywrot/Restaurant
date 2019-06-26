namespace Restaurant.Database.Entities
{
    public class OrderItem
    {
        public virtual int Id { get; set; }
        public virtual Order OrderParent { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual int Quantity { get; set; }
    }
}
