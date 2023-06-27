using eMovie.Data.DTOs;
using eMovie.Models;
using Microsoft.EntityFrameworkCore;

namespace eMovie.Data.Services
{
    public class MoviesService:IMoviesService
    {
        private readonly AppDbContext _context;

        public MoviesService(AppDbContext context)
        {
                _context = context;
        }

        public async Task<List<Movie>> GetAllMovies()
        {
            return await _context.Movies.Include(n=>n.Cinema).ToListAsync();
        }

        public async Task<MovieDropdowns> GetMovieDropdownsValues()
        {
            var response = new MovieDropdowns()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }
    }
}
