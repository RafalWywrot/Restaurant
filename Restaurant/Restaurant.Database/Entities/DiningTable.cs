using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Database.Entities
{
    public class DiningTable
    {
        public virtual int Id { get; set; }
        public virtual int Number { get; set; }
        public virtual int AvailableChairs { get; set; }
    }
}
