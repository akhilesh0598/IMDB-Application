using IMDB_API_Project.Exceptions;
using IMDB_API_Project.Models;
using IMDB_API_Project.Models.Requests;
using IMDB_API_Project.Models.Responses;
using IMDB_API_Project.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMDB_API_Project.Controllers
{
    [Route("api/[controller]")]
    public class ActorsController : BaseController
    {
        private readonly IActorsService _actorService;

        public ActorsController(IActorsService actorService)
        {
            _actorService = actorService;
        }

        // GET: api/<ActorController>
        [HttpGet]
        public IActionResult Get()
        {
            var actors = _actorService.Get();
            return Ok(actors);
        }

        // GET api/<ActorController>/5
        [HttpGet("{actorId}")]
        public IActionResult Get(int actorId)
        {
            try
            {
                if (!_actorService.ValidateId(actorId))
                    throw new EntityNotFoundException($"Actor Id '{actorId}' not found");
                var actor = _actorService.Get(actorId);
                return Ok(actor);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST api/<ActorController>
        [HttpPost]
        public IActionResult Post([FromBody] ActorRequest actorRequest)
        {

            int actorId = _actorService.Add(actorRequest);
            return Created("~api/actors/", new { id = actorId });
        }

        // PUT api/<ActorController>/5
        [HttpPut("{actorId}")]
        public IActionResult Put(int actorId, [FromBody] ActorRequest actorRequest)
        {
            try
            {
                if (!_actorService.ValidateId(actorId))
                    throw new EntityNotFoundException($"Actor Id '{actorId}' not found");
                _actorService.Update(actorId, actorRequest);
                return Ok(new { message = "Updated Successfully" });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // DELETE api/<ActorController>/5
        [HttpDelete("{actorId}")]
        public IActionResult Delete(int actorId)
        {
            try
            {
                if (!_actorService.ValidateId(actorId))
                    throw new EntityNotFoundException($"Actor Id '{actorId}' not found");
                _actorService.Delete(actorId);
                return Ok(new { message="Deleted Successfully" });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}