using System.ComponentModel.DataAnnotations;

namespace Restaurant.WebApplication.Models.Authorization
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} musi posiadać co najmniej {2} znaków.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "Hasła do siebie nie pasuja.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Imię")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Numer telefonu")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Ulica")]
        public string Street { get; set; }
        [Required]
        [Display(Name = "Numer domu")]
        public string StreetNumber { get; set; }
        [Required]
        [Display(Name = "Miasto")]
        public string City { get; set; }
        [Display(Name = "Numer mieszkania")]
        public string FlatNumber { get; set; }
    }
}