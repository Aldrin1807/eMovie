using eMovie.Models;

namespace eMovie.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAllActors();

        Actor GetActorById(int id);
        void AddActor(Actor actor);
        Actor UpdateActor(Actor actor);
        void DeleteActor(int id);


    }
}
