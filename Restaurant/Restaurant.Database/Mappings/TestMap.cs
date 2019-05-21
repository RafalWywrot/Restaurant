using FluentNHibernate.Mapping;
using Restaurant.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Database.Mappings
{
    public class TestMap : ClassMap<Test>
    {
        public TestMap()
        {
            Table("Test");
            Id(x => x.Id);
            Map(x => x.Name, "Name");
        }
    }
}
