using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Blazor.Models
{
    public class RegisterAccountViewModel
    {
        [Required]
        [StringLength(25, ErrorMessage = "Name length can't be more than 25.")]
        public string? Login { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage= "Password must contain digits, uppercase and lowercase letters.")]
        public string? Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
        public string? PasswordRepeat { get; set; }

    }
}
