using eMovie.Data.DTOs;
using eMovie.Models;

namespace eMovie.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAllActors();

        Task<Actor> GetActorById(int id);
        void AddActor(ActorDTO actor);
        Task<Actor> UpdateActor(int id,ActorDTO actor);
        void DeleteActor(int id);


    }
}
