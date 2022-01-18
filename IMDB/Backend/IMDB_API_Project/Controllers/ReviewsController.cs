using IMDB_API_Project.Exceptions;
using IMDB_API_Project.Models.Requests;
using IMDB_API_Project.Models.Responses;
using IMDB_API_Project.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMDB_API_Project.Controllers
{

    [Route("/api/movies/{movieId}/[controller]")]
    public class ReviewsController : BaseController
    {
        private readonly IReviewsService _reviewService;
        private readonly IMoviesService _moviesService;

        public ReviewsController(IReviewsService reviewService, IMoviesService moviesService)
        {
            _reviewService = reviewService;
            _moviesService = moviesService;
        }

        // GET: api/<ReviewController>
        [HttpGet]
        public IActionResult Get(int movieId)
        {
            try
            {
                if (!_moviesService.ValidateId(movieId))
                    throw new EntityNotFoundException($"Movie Id '{movieId}' not found");
                var movieReviews = _reviewService.Get(movieId);
                return Ok(movieReviews);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // GET api/<ReviewController>/5
        [HttpGet("{reviewId}")]
        public IActionResult Get(int movieId, int reviewId)
        {
            try
            {
                if (!_moviesService.ValidateId(movieId))
                    throw new EntityNotFoundException($"Movie Id '{movieId}' not found");
                else if (!_reviewService.ValidateId(movieId, reviewId))
                    throw new EntityNotFoundException($"Review Id '{reviewId}' not found for Movie Id '{movieId}'");
                var movieReview = _reviewService.Get(movieId, reviewId);
                return Ok(movieReview);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST api/<ReviewController>
        [HttpPost]
        public IActionResult Post(int movieId, [FromBody] ReviewRequest review)
        {
            try
            {
                if (!_moviesService.ValidateId(movieId))
                    throw new EntityNotFoundException($"Movie Id '{movieId}' not found");
                int revieId = _reviewService.Add(movieId, review);
                return Created($"~api/movies/'{movieId}'/reviews/", new { id = revieId });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidRequestDataException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        // PUT api/<ReviewController>/5
        [HttpPut("{reviewId}")]
        public IActionResult Put(int movieId, int reviewId, [FromBody] ReviewRequest review)
        {
            try
            {
                if (!_moviesService.ValidateId(movieId))
                    throw new EntityNotFoundException($"Movie Id '{movieId}' not found");
                else if (!_reviewService.ValidateId(movieId, reviewId))
                    throw new EntityNotFoundException($"Review Id '{reviewId}' not found for Movie Id '{movieId}'");
                _reviewService.Update(movieId, reviewId, review);
                return Ok(new { message = "Updated Successfully" });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidRequestDataException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE api/<ReviewController>/5
        [HttpDelete("{reviewId}")]
        public IActionResult Delete(int movieId, int reviewId)
        {
            try
            {
                if (!_moviesService.ValidateId(movieId))
                    throw new EntityNotFoundException($"Movie Id '{movieId}' not found");
                else if (!_reviewService.ValidateId(movieId, reviewId))
                    throw new EntityNotFoundException($"Review Id '{reviewId}' not found for Movie Id '{movieId}'");
                _reviewService.Delete(movieId, reviewId);
                return Ok(new { message = "Deleted Successfully" });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}