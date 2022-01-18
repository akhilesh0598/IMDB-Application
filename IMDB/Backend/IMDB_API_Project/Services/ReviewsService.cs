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
    public class ReviewsService : IReviewsService
    {
        private readonly IReviewsRepository _reviewRepository;
        private readonly IMoviesService _moviesService;

        public ReviewsService(IReviewsRepository reviewsRepository, IMoviesService moviesService)
        {
            _reviewRepository = reviewsRepository;
            _moviesService = moviesService;
        }

        public int Add(int movieId, ReviewRequest reviewRequest)
        {
            if (movieId != reviewRequest.MovieId)
                throw new InvalidRequestDataException($"Route Movie Id '{movieId}' and body Movie Id '{reviewRequest.MovieId}' should be same");
            var review = new Review()
            {
                Message = reviewRequest.Message,
                MovieId = reviewRequest.MovieId
            };
            return _reviewRepository.Create(movieId, review);
        }

        public ReviewResponse Get(int movieId, int reviewId)
        {
            var review = _reviewRepository.Get(movieId, reviewId);
            if (review == null)
                return null;
            return new ReviewResponse()
            {
                Id = review.Id,
                Message = review.Message,
                Movie = _moviesService.Get(review.MovieId)
            };
        }

        public List<ReviewResponse> Get(int movieId)
        {
            var reviews = _reviewRepository.Get(movieId).Select((x) => new ReviewResponse()
            {
                Id = x.Id,
                Message = x.Message,
                Movie = _moviesService.Get(movieId),
            }).ToList();
            return reviews;
        }

        public void Update(int movieId, int reviewId, ReviewRequest review)
        {
            if (movieId != review.MovieId)
                throw new InvalidRequestDataException($"Route Movie Id '{movieId}' and body Movie Id '{review.MovieId}' should be same");
            _reviewRepository.Update(movieId, reviewId, new Review()
            {
                Id = reviewId,
                Message = review.Message,
                MovieId = review.MovieId
            });
        }

        public void Delete(int movieId, int reviewId)
        {
            _reviewRepository.Delete(movieId, reviewId);
        }

        public bool ValidateId(int movieId, int reviewId)
        {
            var review = _reviewRepository.Get(movieId, reviewId);
            if (review == null)
                return false;
            return true;
        }
    }
}
