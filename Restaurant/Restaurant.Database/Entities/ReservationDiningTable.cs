using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Database.Entities
{
    public class ReservationDiningTable
    {
        public virtual int Id { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual DiningTable DiningTable { get; set; }
    }
}
