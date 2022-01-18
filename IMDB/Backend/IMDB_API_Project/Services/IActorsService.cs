using IMDB_API_Project.Models.DB;
using IMDB_API_Project.Models.Requests;
using IMDB_API_Project.Models.Responses;
using System.Collections.Generic;

namespace IMDB_API_Project.Services
{
    public interface IActorsService
    {
        int Add(ActorRequest actorRequest);
        ActorResponse Get(int actorId);
        List<ActorResponse> Get();
        List<ActorResponse> Get(List<int> actorsIds);
        void Update(int actorId, ActorRequest actorRequest);
        void Delete(int actorId);
        bool ValidateId(int actorId);
        List<ActorResponse> GetByMovieId(int movieId);
    }
}