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

        public void AddActor(Actor actor)
        {
           _context.Actors.Add(actor);
           _context.SaveChanges();
        }

        public void DeleteActor(int id)
        {
            throw new NotImplementedException();
        }

        public Actor GetActorById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Actor>> GetAllActors()
        {
            var data = await _context.Actors.ToListAsync();
            return data;
        
        }

        public Actor UpdateActor(Actor actor)
        {
            throw new NotImplementedException();
        }
    }
}
