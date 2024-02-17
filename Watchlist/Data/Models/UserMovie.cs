using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Watchlist.Data.Models
{
    public class UserMovie
    {
        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        [Required]
        [Comment("Movie identifier")]
        public int MovieId { get; set; }

        [ForeignKey(nameof(MovieId))] 
        public Movie Movie { get; set; } = null!;
    }
}
