using System.Diagnostics.Eventing.Reader;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Watchlist.Data;
using Watchlist.Data.Models;
using Watchlist.Models;

namespace Watchlist.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly WatchlistDbContext _context;

        public MoviesController(WatchlistDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await _context.Movies
                .Select(m => new MovieViewModel()
                {
                    Genre = m.Genre.Name,
                    Title = m.Title,
                    Director = m.Director,
                    ImageUrl = m.ImageUrl,
                    Rating = m.Rating,
                    Id = m.Id
                })
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var genres = await _context.Genres.ToListAsync();

            var model = new AddMovieViewModel()
            {
                Genres = genres
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var movie = new Movie()
            {
                Director = model.Director,
                GenreId = model.GenreId,
                ImageUrl = model.ImageUrl,
                Title = model.Title,
                Rating = model.Rating
            };

            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int movieId)
        {
            var model = await _context.Movies
                .Where(m => m.Id == movieId)
                .Select(m => new MovieViewModel()
                {
                    Id = m.Id,
                    Director = m.Director,
                    ImageUrl = m.ImageUrl,
                    Rating = m.Rating,
                    Title = m.Title,
                    Genre = m.Genre.Name
                })
                .FirstOrDefaultAsync();
            
            if (model == null)
            {
                return RedirectToAction(nameof(All));
            }

            var userId = GetUserId();

            var inCollectionAlready = await _context.UsersMovies
                .Where(um => um.MovieId == model.Id && um.UserId == userId)
                .FirstOrDefaultAsync();
            if (inCollectionAlready == null)
            {
                var userMovie = new UserMovie()
                {
                    UserId = userId,
                    MovieId = model.Id
                };

                await _context.UsersMovies.AddAsync(userMovie);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Watched()
        {
            var userId = GetUserId();

            var model = await _context.UsersMovies
                .Where(m => m.UserId == userId)
                .Select(m => new MovieViewModel()
                {
                    Id = m.Movie.Id,
                    Director = m.Movie.Director,
                    Genre = m.Movie.Genre.Name,
                    ImageUrl = m.Movie.ImageUrl,
                    Rating = m.Movie.Rating,
                    Title = m.Movie.Title
                })
                .ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            var userId = GetUserId();
            var movie = await _context.UsersMovies
                .Where(um => um.MovieId == movieId && um.UserId == userId)
                .FirstOrDefaultAsync();
        
            if (movie != null)
            {
                _context.UsersMovies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        
            return RedirectToAction(nameof(Watched));
        }


        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
