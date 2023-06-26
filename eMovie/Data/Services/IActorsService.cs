using eMovie.Data.DTOs;
using eMovie.Models;

namespace eMovie.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAllActors();

       async Task<Actor> GetActorById(int id);
        void AddActor(ActorDTO actor);
        Actor UpdateActor(Actor actor);
        void DeleteActor(int id);


    }
}
