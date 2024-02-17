using System.ComponentModel.DataAnnotations;
using Watchlist.Data.Constants;
using Watchlist.Data.Models;

namespace Watchlist.Models
{
    public class AddMovieViewModel
    {
        [Required]
        [StringLength(DataConstants.MovieTitleMaxLength,
            MinimumLength = DataConstants.MovieTitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.MovieDirectorMaxLength,
            MinimumLength = DataConstants.MovieDirectorMinLength)]
        public string Director { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(DataConstants.MovieRatingMinValue, 
            DataConstants.MovieRatingMaxValue)]
        public decimal Rating { get; set; }

        public int GenreId { get; set; }

        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    }
}
