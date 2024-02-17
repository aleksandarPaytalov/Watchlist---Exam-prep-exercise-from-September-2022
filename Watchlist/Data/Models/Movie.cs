using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Watchlist.Data.Constants;

namespace Watchlist.Data.Models
{
    [Comment("Movie Data model")]
    public class Movie
    {
        [Key]
        [Comment("Movie identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.MovieTitleMaxLength)]
        [Comment("Movie title")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DataConstants.MovieDirectorMaxLength)]
        [Comment("Movie director")]
        public string Director { get; set; } = null!;

        [Required]
        [Comment("Movie image Url")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Comment("Rating of the movie")]
        public decimal Rating { get; set; }

        [Required]
        [Comment("Genre identifier")]
        public int GenreId { get; set; }

        [Required]
        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; } = null!;

        public ICollection<UserMovie> UsersMovies { get; set; } = new List<UserMovie>();
    }
}
