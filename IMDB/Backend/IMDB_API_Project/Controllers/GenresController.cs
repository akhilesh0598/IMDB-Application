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
    [Route("api/[controller]")]
    public class GenresController : BaseController
    {
        private readonly IGenresService _genreService;

        public GenresController(IGenresService genresService)
        {
            _genreService = genresService;
        }

        // GET: api/<GenreController>
        [HttpGet]
        public IActionResult Get()
        {
            var genres = _genreService.Get();
            return Ok(genres);
        }

        // GET api/<GenreController>/5
        [HttpGet("{genreId}")]
        public IActionResult Get(int genreId)
        {
            try
            {
                if (!_genreService.ValidateId(genreId))
                    throw new EntityNotFoundException($"Genre Id '{genreId}' not found");
                var genre = _genreService.Get(genreId);
                return Ok(genre);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST api/<GenreController>
        [HttpPost]
        public IActionResult Post([FromBody] GenreRequest genreRequest)
        {
            int genreId = _genreService.Add(genreRequest);
            return Created("~api/genres/", new { id = genreId });
        }

        // PUT api/<GenreController>/5
        [HttpPut("{genreId}")]
        public IActionResult Put(int genreId, [FromBody] GenreRequest genreRequest)
        {
            try
            {
                if (!_genreService.ValidateId(genreId))
                    throw new EntityNotFoundException($"Genre Id '{genreId}' not found");
                _genreService.Update(genreId, genreRequest);
                return Ok(new { message = "Updated Successfully" });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{genreId}")]
        public IActionResult Delete(int genreId)
        {
            try
            {
                if (!_genreService.ValidateId(genreId))
                    throw new EntityNotFoundException($"Genre Id '{genreId}' not found");
                _genreService.Delete(genreId);
                return Ok(new { message = "Deleted Successfully" });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}