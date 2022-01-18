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
    public class ProducersController : BaseController
    {
        private readonly IProducersService _producerService;
        public ProducersController(IProducersService producerService)
        {
            _producerService = producerService;
        }

        // GET: api/<ProducerController>
        [HttpGet]
        public IActionResult Get()
        {
            var producers = _producerService.Get();
            return Ok(producers);
        }

        // GET api/<ProducerController>/5
        [HttpGet("{producerId}")]
        public IActionResult Get(int producerId)
        {
            try
            {
                if (!_producerService.ValidateId(producerId))
                    throw new EntityNotFoundException($"Producer Id '{producerId}' not found");
                var producer = _producerService.Get(producerId);
                return Ok(producer);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST api/<ProducerController>
        [HttpPost]
        public IActionResult Post([FromBody] ProducerRequest producer)
        {
            int producerId = _producerService.Add(producer);
            return Created("~api/producers/", new { id = producerId });
        }

        // PUT api/<ProducerController>/5
        [HttpPut("{producerId}")]
        public IActionResult Put(int producerId, [FromBody] ProducerRequest producer)
        {
            try
            {
                if (!_producerService.ValidateId(producerId))
                    throw new EntityNotFoundException($"Producer Id '{producerId}' not found");
                _producerService.Update(producerId, producer);
                return Ok(new { message = "Updated Successfully" });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // DELETE api/<ProducerController>/5
        [HttpDelete("{producerId}")]
        public IActionResult Delete(int producerId)
        {
            try
            {
                if (!_producerService.ValidateId(producerId))
                    throw new EntityNotFoundException($"Producer Id '{producerId}' not found");
                _producerService.Delete(producerId);
                return Ok(new { message = "Deleted Successfully" });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}