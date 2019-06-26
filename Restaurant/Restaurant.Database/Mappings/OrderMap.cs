using FluentNHibernate.Mapping;
using Restaurant.Database.Entities;

namespace Restaurant.Database.Mappings
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Table("Orders");

            Id(x => x.Id);
            Map(x => x.OrderDate, "OrderDate");
            Map(x => x.Status, "Status");
            Map(x => x.PickupDate, "PickupDate");

            References(x => x.User, "UserId").Not.LazyLoad();
            HasMany(x => x.OrderItems)
              .KeyColumn("OrderId")
              .Inverse()
              .Cascade
              .AllDeleteOrphan()
              .Not.LazyLoad();
        }
    }
}
