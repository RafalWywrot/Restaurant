using FluentNHibernate.Mapping;
using Restaurant.Database.Entities;

namespace Restaurant.Database.Mappings
{
    public class MenuMap : ClassMap<Menu>
    {
        public MenuMap()
        {
            Table("Menu");
            Id(x => x.Id);
            Map(x => x.Name, "Name").Not.Nullable();
            Map(x => x.Price, "Price").Not.Nullable();
            Map(x => x.Ingredients, "Ingredients").Not.Nullable();
        }
    }
}
