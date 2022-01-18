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
    public class GenresService : IGenresService
    {
        private readonly IGenresRepository _genreRepository;

        public GenresService(IGenresRepository genresRepository)
        {
            _genreRepository = genresRepository;
        }

        public int Add(GenreRequest genreRequest)
        {
            var genre = new Genre()
            {
                Name = genreRequest.Name
            };
            return _genreRepository.Create(genre);
        }

        public GenreResponse Get(int genreId)
        {
            var genre = _genreRepository.Get(genreId);

            if (genre == null)
                return null;
            var genreResponse = new GenreResponse()
            {
                Id = genre.Id,
                Name = genre.Name
            };
            return genreResponse;
        }

        public List<GenreResponse> Get()
        {
            var genresResponse = _genreRepository.Get().Select((x) => new GenreResponse()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return genresResponse;
        }

        public void Update(int genreId, GenreRequest requestGenre)
        {
            var genre = new Genre()
            {
                Id = genreId,
                Name = requestGenre.Name
            };
            _genreRepository.Update(genreId, genre);
        }

        public void Delete(int genreId)
        {
            _genreRepository.Delete(genreId);
        }

        public List<GenreResponse> GetByMovieId(int movieId)
        {
            return _genreRepository.GetByMovieId(movieId).Select(x => new GenreResponse()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public List<GenreResponse> Get(List<int> genresIds)
        {
            return _genreRepository.Get(genresIds).Select(x => new GenreResponse()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public bool ValidateId(int genreId)
        {
            var actor = _genreRepository.Get(genreId);
            if (actor == null)
                return false;
            return true;
        }
    }
}