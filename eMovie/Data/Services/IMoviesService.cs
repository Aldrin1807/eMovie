using eMovie.Data.DTOs;
using eMovie.Models;

namespace eMovie.Data.Services
{
    public interface IMoviesService
    {
        Task<List<Movie>> GetAllMovies();
        Task<MovieDropdowns> GetMovieDropdownsValues();
    }
}
