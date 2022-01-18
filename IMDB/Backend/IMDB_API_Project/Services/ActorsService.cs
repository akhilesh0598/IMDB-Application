using IMDB_API_Project.Exceptions;
using IMDB_API_Project.Models.DB;
using IMDB_API_Project.Models.Requests;
using IMDB_API_Project.Models.Responses;
using IMDB_API_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMDB_API_Project.Services
{
    public class ActorsService : IActorsService
    {
        private readonly IActorsRepository _actorRepository;

        public ActorsService(IActorsRepository actorsRepository)
        {
            _actorRepository = actorsRepository;
        }

        public int Add(ActorRequest actorRequest)
        {
            var actor = new Actor()
            {
                Name = actorRequest.Name,
                Bio = actorRequest.Bio,
                DOB = actorRequest.DOB,
                Gender = actorRequest.Gender
            };
            var actorId = _actorRepository.Create(actor);
            return actorId;
        }

        public ActorResponse Get(int actorId)
        {
            var actor = _actorRepository.Get(actorId);
            if (actor == null)
                return null;
            var actorResponse = new ActorResponse()
            {
                Id = actor.Id,
                Name = actor.Name,
                Bio = actor.Bio,
                DOB = actor.DOB,
                Gender = actor.Gender
            };
            return actorResponse;
        }

        public List<ActorResponse> Get()
        {
            var actorsResponse = _actorRepository.Get().Select((x) => new ActorResponse()
            {
                Id = x.Id,
                Name = x.Name,
                Bio = x.Bio,
                DOB = x.DOB,
                Gender = x.Gender
            }).ToList();
            return actorsResponse;
        }

        public void Update(int actorId, ActorRequest actorRequest)
        {
            var actor = new Actor()
            {
                Id = actorId,
                Name = actorRequest.Name,
                Bio = actorRequest.Bio,
                DOB = actorRequest.DOB,
                Gender = actorRequest.Gender
            };
            _actorRepository.Update(actorId, actor);
        }

        public void Delete(int actorId)
        {
            _actorRepository.Delete(actorId);
        }

        public List<ActorResponse> GetByMovieId(int movieId)
        {
            return _actorRepository.GetByMovieId(movieId).Select(x => new ActorResponse()
            {
                Id=x.Id,
                Name=x.Name,
                Bio=x.Bio,
                DOB=x.DOB,
                Gender=x.Gender
            }).ToList();
        }

        public List<ActorResponse> Get(List<int>actorsIds)
        {
            return _actorRepository.Get(actorsIds).Select(x => new ActorResponse()
            {
                Id = x.Id,
                Name = x.Name,
                Bio = x.Bio,
                DOB = x.DOB,
                Gender = x.Gender
            }).ToList();
        }

        public bool ValidateId(int actorId)
        {
            var actor = _actorRepository.Get(actorId);
            if (actor == null)
                return false;
            return true;
        }
    }
}