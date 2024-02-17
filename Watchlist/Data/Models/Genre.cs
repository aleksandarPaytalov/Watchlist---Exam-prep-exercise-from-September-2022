using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Watchlist.Data.Constants;

namespace Watchlist.Data.Models
{
    [Comment("Movies genre")]
    public class Genre
    {
        [Key]
        [Comment("Genre Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.GenreNameMaxLength)]
        [Comment("Genre name")]
        public string Name { get; set; } = null!;
    }
}