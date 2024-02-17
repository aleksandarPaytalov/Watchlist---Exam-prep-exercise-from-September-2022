using System.ComponentModel.DataAnnotations;
using Watchlist.Data.Constants;

namespace Watchlist.Models
{
    public class LoginViewModel
    {
        // Тук може да не проверяваме дължините, защото го правим в регистрацията
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
