using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebApplication.Models
{
    public class DiningTableFormViewModel
    {
        [Required]
        [Display(Name = "Liczba stolików")]
        public int SelectedNumberOfChairs { get; set; }
        public IEnumerable<SelectListItem> ChairsOptions { get; set; }
        [Required]
        [Display(Name = "Data")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "Godzina od")]
        public DateTime StartTime { get; set; }
        [Required]
        [Display(Name = "Godzina do")]
        public DateTime EndTime { get; set; }
        public List<DiningTableViewModel> AvailableTables { get; set; }
    }
}