using eMovie.Data.DTOs;
using eMovie.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public async Task CreateMovie(MovieDTO movie)
        {
            var newMovie = new Movie()
            {
                Name = movie.Name,
                Description = movie.Description,
                Price = movie.Price,
                ImageURL = movie.ImageURL,
                CinemaId = movie.CinemaId,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
                MovieCategory = movie.MovieCategory,
                ProducerId = movie.ProducerId
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in movie.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }


        public async Task<Movie> GetMovieById(int id)
        {
            return await _context.Movies.Include(n => n.Cinema).Include(n => n.Producer).Include(n => n.Actors_Movies).ThenInclude(n => n.Actor).FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task UpdateMovie(MovieDTO movieDTO)
        {
            var movie = await _context.Movies.Include(n => n.Actors_Movies).FirstOrDefaultAsync(n => n.Id == movieDTO.Id);
            if (movie == null)
            {
                return;
            }

            movie.Name = movieDTO.Name;
            movie.Description = movieDTO.Description;
            movie.Price = movieDTO.Price;
            movie.ImageURL = movieDTO.ImageURL;
            movie.CinemaId = movieDTO.CinemaId;
            movie.StartDate = movieDTO.StartDate;
            movie.EndDate = movieDTO.EndDate;
            movie.MovieCategory = movieDTO.MovieCategory;
            movie.ProducerId = movieDTO.ProducerId;

            //Delete Movie Actors
            foreach (var actorMovie in movie.Actors_Movies)
            {
                _context.Actors_Movies.Remove(actorMovie);
            }
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in movieDTO.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = movie.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }


        public async Task<List<Movie>> Filter(string searchString)
        {
            var movies = await _context.Movies.Include(n => n.Cinema).Include(n => n.Producer).Include(n => n.Actors_Movies).ThenInclude(n => n.Actor).Where(m => searchString.Contains(m.Name)).ToListAsync();

            return movies;
        }
    }
}
