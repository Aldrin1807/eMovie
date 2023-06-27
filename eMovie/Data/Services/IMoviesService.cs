using eMovie.Data.DTOs;
using eMovie.Models;

namespace eMovie.Data.Services
{
    public interface IMoviesService
    {
        Task<List<Movie>> GetAllMovies();
        Task<MovieDropdowns> GetMovieDropdownsValues();

        Task CreateMovie(MovieDTO movieDTO);

        Task<Movie> GetMovieById(int id);

        Task UpdateMovie(MovieDTO movieDTO);
    }
}
