using Restaurant.Database;
using Restaurant.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.WebApplication.Models
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ApplicationUser User { get; set; }
        public DiningTableViewModel DiningTable { get; set; }

    }
}