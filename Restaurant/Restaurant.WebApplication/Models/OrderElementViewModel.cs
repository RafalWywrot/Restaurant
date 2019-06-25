using System.ComponentModel.DataAnnotations;

namespace Restaurant.WebApplication.Models
{
    public class OrderElementViewModel : MenuViewModel
    {
        [Required]
        [Display(Name = "Ilość")]
        public int Amount { get; set; }
    }
}