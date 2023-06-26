using eMovie.Data.DTOs;
using eMovie.Models;
using Microsoft.EntityFrameworkCore;

namespace eMovie.Data.Services
{
    public class ActorsService: IActorsService
    {
        private readonly AppDbContext _context;

        public ActorsService(AppDbContext context)
        {
                _context= context;
        }

        public async void AddActor(ActorDTO actor)
        {
            var _actor = new Actor
            {
                FullName = actor.FullName,
                Bio = actor.Bio,
                ProfilePictureURL = actor.ProfilePictureURL
            };
          await _context.Actors.AddAsync(_actor);
           _context.SaveChanges();
        }

        public void DeleteActor(int id)
        {
            var actor = _context.Actors.FirstOrDefault(a => a.Id == id);
            if (actor != null)
            {
                _context.Actors.Remove(actor);
              _context.SaveChangesAsync();
            }
        }

        public async Task<Actor> GetActorById(int id)
        {
            var actor =await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);
            return actor;
        }

        public async Task<IEnumerable<Actor>> GetAllActors()
        {
            var data = await _context.Actors.ToListAsync();
            return data;
        
        }

        public async Task<Actor> UpdateActor(int id,ActorDTO actor)
        {
            var _actor = await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);
            _actor.FullName = actor.FullName;
            _actor.Bio = actor.Bio;
            _actor.ProfilePictureURL = actor.ProfilePictureURL;
            _context.SaveChangesAsync();
            return _actor;
        }
    }
}
