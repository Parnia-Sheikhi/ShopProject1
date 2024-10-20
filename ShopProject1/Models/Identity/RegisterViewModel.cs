using System.ComponentModel.DataAnnotations;

namespace ShopProject1.Models.Identity
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "طوا پسورد باید مناسب باشد ", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "پسورد و تایید پسورد باید یکی باشند ")]
        public string ConfirmPassword { get; set; }

    }
}
