using IMDB_API_Project.Exceptions;
using IMDB_API_Project.ImageUploaderFile;
using IMDB_API_Project.Models.DB;
using IMDB_API_Project.Models.Requests;
using IMDB_API_Project.Models.Responses;
using IMDB_API_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMDB_API_Project.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly IActorsService _actorService;
        private readonly IGenresService _genreService;
        private readonly IProducersService _producerService;

        public MoviesService(IMoviesRepository moviesRepository,IActorsService actorService,
            IGenresService genreService, IProducersService producerService)
        {
            _moviesRepository = moviesRepository;
            _actorService = actorService;
            _genreService = genreService;
            _producerService = producerService;
        }

        public int Add(MovieRequest requestMovie)
        {
            ValidateRequestData(requestMovie);
            var movie = new Movie()
            {
                Name = requestMovie.Name,
                YearOfRelease = requestMovie.YearOfRelease,
                Plot = requestMovie.Plot,
                ProducerId = requestMovie.ProducerId,
                ImageUrl = requestMovie.ImageUrl
            };
            return _moviesRepository.Create(movie, requestMovie.ActorsIds, requestMovie.GenresIds);
        }

        public List<MovieResponse> Get()
        {
            var moviesResponse = _moviesRepository.Get().Select((x) => new MovieResponse()
            {
                Id = x.Id,
                Name = x.Name,
                YearOfRelease = x.YearOfRelease,
                Plot = x.Plot,
                Producer = _producerService.Get(x.ProducerId),
                Actors = _actorService.GetByMovieId(x.Id),
                Genres = _genreService.GetByMovieId(x.Id),
                ImageUrl = x.ImageUrl
            }).ToList();
            return moviesResponse;
        }

        public MovieResponse Get(int movieId)
        {
            var movie = _moviesRepository.Get(movieId);
            if (movie == null)
                return null;
            
            var movieResponse = new MovieResponse
            {
                Id = movie.Id,
                Name = movie.Name,
                YearOfRelease = movie.YearOfRelease,
                Plot = movie.Plot,
                Producer =_producerService.Get(movie.ProducerId),
                Actors = _actorService.GetByMovieId(movie.Id),
                Genres = _genreService.GetByMovieId(movie.Id),
                ImageUrl = movie.ImageUrl
            };
            return movieResponse;
        }

        public void Update(int movieId, MovieRequest requestMovie)
        {
            ValidateRequestData(requestMovie);
            _moviesRepository.Update(movieId, new Movie()
            {
                Name = requestMovie.Name,
                YearOfRelease = requestMovie.YearOfRelease,
                Plot = requestMovie.Plot,
                ProducerId = requestMovie.ProducerId,
                ImageUrl = requestMovie.ImageUrl
            }, requestMovie.ActorsIds, requestMovie.GenresIds);
        }

        public void Delete(int movieId)
        {
            _moviesRepository.Delete(movieId);
        }

        public bool ValidateId(int movieId)
        {
            var movie = _moviesRepository.Get(movieId);
            if (movie == null)
                return false;
            return true;
        }

        private void ValidateRequestData(MovieRequest requestMovie)
        {
            var producer = _producerService.Get(requestMovie.ProducerId);
            if (producer == null)
                throw new InvalidRequestDataException($"Producer Id '{requestMovie.ProducerId}' not found");

            var actorsIds = requestMovie.ActorsIds;
            var actorsIdsPresent = _actorService.Get(actorsIds).Select((x) => x.Id);
            var actorsIdsNotPresent = actorsIds.Except(actorsIdsPresent);
            if (actorsIdsNotPresent.Count() != 0)
                throw new InvalidRequestDataException($"These Actors Id '{string.Join(',', actorsIdsNotPresent)}' not found");

            var genresIds = requestMovie.GenresIds;
            var genresIdsPresent = _genreService.Get(genresIds).Select((x) => x.Id);
            var genresIdsNotPresent = genresIds.Except(genresIdsPresent);
            if (genresIdsNotPresent.Count() != 0)
                throw new InvalidRequestDataException($"These Genres Id '{string.Join(',', genresIdsNotPresent)}' not found");
        }

        public ImageResponse UploadImage(ImageRequest imageRequest)
        {
            var clientImageUploader = new ClientImageUploader();
            var imageLink = clientImageUploader.FileUpload(imageRequest.File);
            return new ImageResponse()
            {
                Image = imageLink
            };
        }
    }
}