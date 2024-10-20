using System.ComponentModel.DataAnnotations;

namespace ShopProject1.Models.Identity
{
    public class LoginModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [UIHint("password")] // برای اینکه تکست باکس ان برای پسورد باشه
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}
