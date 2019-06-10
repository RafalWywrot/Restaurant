using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant.WebApplication.Models
{
    public class DiningTableViewModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int AvailableChairs { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}