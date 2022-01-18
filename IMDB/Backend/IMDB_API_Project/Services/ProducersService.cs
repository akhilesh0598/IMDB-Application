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
    public class ProducersService : IProducersService
    {
        private readonly IProducersRepository _producerRepository;

        public ProducersService(IProducersRepository producersRepository)
        {
            _producerRepository = producersRepository;
        }

        public int Add(ProducerRequest producerRequest)
        {
            var producer = new Producer()
            {
                Name = producerRequest.Name,
                Bio = producerRequest.Bio,
                DOB = producerRequest.DOB,
                Gender = producerRequest.Gender
            };
            return _producerRepository.Create(producer);
        }

        public List<ProducerResponse> Get()
        {
            return _producerRepository.Get().Select((x) => new ProducerResponse()
            {
                Id = x.Id,
                Name = x.Name,
                Bio = x.Bio,
                DOB = x.DOB,
                Gender = x.Gender
            }).ToList();
        }

        public ProducerResponse Get(int producerId)
        {
            var producer = _producerRepository.Get(producerId);
            if (producer == null)
                return null;
            return new ProducerResponse()
            {
                Id = producer.Id,
                Name = producer.Name,
                Bio = producer.Bio,
                DOB = producer.DOB,
                Gender = producer.Gender
            };
        }

        public void Update(int producerId, ProducerRequest producerRequest)
        {
            _producerRepository.Update(producerId, new Producer()
            {
                Id = producerId,
                Name = producerRequest.Name,
                Bio = producerRequest.Bio,
                DOB = producerRequest.DOB,
                Gender = producerRequest.Gender
            });
        }

        public void Delete(int producerId)
        {
            _producerRepository.Delete(producerId);
        }

        public bool ValidateId(int producerId)
        {
            var producer = _producerRepository.Get(producerId);
            if (producer == null)
                return false;
            return true;
        }
    }
}