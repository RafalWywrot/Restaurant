using System.ComponentModel.DataAnnotations;

namespace Restaurant.WebApplication.Models
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Cena")]
        public decimal Price { get; set; }
    }
}