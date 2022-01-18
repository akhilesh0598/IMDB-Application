using IMDB_API_Project.Models.DB;
using System.Collections.Generic;

namespace IMDB_API_Project.Repository
{
    public interface IActorsRepository
    {
        int Create(Actor actor);
        Actor Get(int actorId);
        IEnumerable<Actor> Get();
        IEnumerable<Actor> Get(List<int> actorsIds);
        void Update(int actorId, Actor actor);
        void Delete(int actorId);
        IEnumerable<Actor> GetByMovieId(int movieId);
    }
}