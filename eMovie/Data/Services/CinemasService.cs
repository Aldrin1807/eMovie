using eMovie.Data.DTOs;
using eMovie.Models;
using Microsoft.EntityFrameworkCore;

namespace eMovie.Data.Services
{
    public class CinemasService:ICinemasService
    {
        private readonly AppDbContext _context;

        public CinemasService(AppDbContext context)
        {
            _context = context;
        }

        public  IEnumerable<Cinema> GetAllCinemas()
        {
            return  _context.Cinemas.ToList();
        }

        public async Task<Cinema> GetCinemaById(int id)
        {
            return await _context.Cinemas.FindAsync(id);
        }

        public async void AddCinema(CinemaDTO cinema)
        {
            var newCinema = new Cinema
            {
                Name = cinema.Name,
                Description = cinema.Description,
                Logo = cinema.Logo
            };
            await _context.Cinemas.AddAsync(newCinema);
            _context.SaveChanges();
        }

        public async Task<Cinema> UpdateCinema(int id, CinemaDTO cinema)
        {
            var cinemaToUpdate = await _context.Cinemas.FindAsync(id);
            if (cinemaToUpdate == null)
            {
                return null;
            }
            cinemaToUpdate.Name = cinema.Name;
            cinemaToUpdate.Description = cinema.Description;
            cinemaToUpdate.Logo = cinema.Logo;
            _context.SaveChanges();
            return cinemaToUpdate;
        }

        public async void DeleteCinema(int id)
        {
            var cinemaToDelete = await _context.Cinemas.FindAsync(id);
            if (cinemaToDelete == null)
            {
                return;
            }
            _context.Cinemas.Remove(cinemaToDelete);
            _context.SaveChanges();
        }

    }
}
