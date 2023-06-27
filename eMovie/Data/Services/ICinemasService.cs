using eMovie.Data.DTOs;
using eMovie.Models;

namespace eMovie.Data.Services
{
    public interface ICinemasService
    {
        IEnumerable<Cinema> GetAllCinemas();

        Task<Cinema> GetCinemaById(int id);
        void AddCinema(CinemaDTO cinema);
        Task<Cinema> UpdateCinema(int id, CinemaDTO cinema);
        void DeleteCinema(int id);

    }
}
