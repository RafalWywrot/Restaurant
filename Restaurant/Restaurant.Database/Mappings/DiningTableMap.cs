using FluentNHibernate.Mapping;
using Restaurant.Database.Entities;

namespace Restaurant.Database.Mappings
{
    public class DiningTableMap : ClassMap<DiningTable>
    {
        public DiningTableMap()
        {
            Table("DiningTable");
            Id(x => x.Id);
            Map(x => x.Number, "Number").Not.Nullable();
            Map(x => x.AvailableChairs, "Size").Not.Nullable();
        }
    }
}
