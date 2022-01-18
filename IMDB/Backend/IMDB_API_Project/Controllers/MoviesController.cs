using IMDB_API_Project.Exceptions;
using IMDB_API_Project.Models.Requests;
using IMDB_API_Project.Models.Responses;
using IMDB_API_Project.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMDB_API_Project.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : BaseController
    {
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        // GET: api/<MovieController>
        [HttpGet]
        public IActionResult Get()
        {
            var movies = _moviesService.Get();
            return Ok(movies);
        }

        // GET api/<MovieController>/5
        [HttpGet("{movieId}")]
        public IActionResult Get(int movieId)
        {
            try
            {
                if (!_moviesService.ValidateId(movieId))
                    throw new EntityNotFoundException($"Movie Id '{movieId}' not found");
                var movie = _moviesService.Get(movieId);
                return Ok(movie);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST api/<MovieController>
        [HttpPost]
        public IActionResult Post([FromBody] MovieRequest movieRequest)
        {
            try
            {
                int movieId = _moviesService.Add(movieRequest);
                return Created("~api/movies/", new { id = movieId });
            }
            catch (InvalidRequestDataException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT api/<MovieController>/5
        [HttpPut("{movieId}")]
        public IActionResult Put(int movieId, [FromBody] MovieRequest movieRequest)
        {
            try
            {
                if (!_moviesService.ValidateId(movieId))
                    throw new EntityNotFoundException($"Movie Id '{movieId}' not found");
                _moviesService.Update(movieId, movieRequest);
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

        // DELETE api/<MovieController>/5
        [HttpDelete("{movieId}")]
        public IActionResult Delete(int movieId)
        {
            try
            {
                if (!_moviesService.ValidateId(movieId))
                    throw new EntityNotFoundException($"Movie Id '{movieId}' not found");
                _moviesService.Delete(movieId);
                return Ok(new { message = "Deleted Successfully" });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost("[Action]")]
        public IActionResult UploadImage([FromForm] ImageRequest imageRequest)
        {
            try
            {
                var imageResponse = _moviesService.UploadImage(imageRequest);
                if (imageResponse.Image == null)
                    throw new EntityNotFoundException($"Image has not created");
                return Ok(imageResponse.Image);
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
    }
}