using Restaurant.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.DTO
{
    public class ReservationDiningTableDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ApplicationUser User { get; set; }
        public DiningTableDTO DiningTable { get; set; }
    }
}
