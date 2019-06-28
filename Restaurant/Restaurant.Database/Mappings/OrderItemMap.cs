using FluentNHibernate.Mapping;
using Restaurant.Database.Entities;

namespace Restaurant.Database.Mappings
{
    public class OrderItemMap : ClassMap<OrderItem>
    {
        public OrderItemMap()
        {
            Table("OrderItem");
            Id(x => x.Id);
            Map(x => x.Quantity, "Quantity");
            References(x => x.OrderParent, "OrderId");
            References(x => x.Menu, "MenuId").Not.LazyLoad();
        }
    }
}
