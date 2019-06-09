using FluentNHibernate.Mapping;
using Restaurant.Database.Entities;

namespace Restaurant.Database.Mappings
{
    public class ReservationDiningTableMap : ClassMap<ReservationDiningTable>
    {
        public ReservationDiningTableMap()
        {
            Table("ReservationDiningTable");
            Id(x => x.Id);
            Map(x => x.StartDate, "StartDate").Not.Nullable();
            Map(x => x.EndDate, "EndDate").Not.Nullable();
            References(x => x.DiningTable, "DiningTableId").Not.LazyLoad();
            References(x => x.User, "UserId");
        }
    }
}
