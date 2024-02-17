using System.ComponentModel.DataAnnotations;
using Watchlist.Data.Constants;

namespace Watchlist.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(DataConstants.UserNameMaxLength,
            MinimumLength = DataConstants.UserNameMinLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.UserPasswordMaxLength,
            MinimumLength = DataConstants.UserPasswordMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(DataConstants.UserEmailMaxLength,
            MinimumLength = DataConstants.UserEmailMinLength)]
        public string Email { get; set; } = null!;

        
    }
}
