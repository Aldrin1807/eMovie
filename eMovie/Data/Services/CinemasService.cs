using eMovie.Data.DTOs;
using eMovie.Models;
using Microsoft.EntityFrameworkCore;

namespace eMovie.Data.Services
{
    public class CinemasService:ICinemaService
    {
        private readonly AppDbContext _context;

        public CinemasService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cinema>> GetAllCinemas()
        {
            return await _context.Cinemas.ToListAsync();
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
            await _context.SaveChangesAsync();
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
            await _context.SaveChangesAsync();
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
            await _context.SaveChangesAsync();
        }

    }
}
