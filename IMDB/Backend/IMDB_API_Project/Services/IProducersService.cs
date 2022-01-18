using IMDB_API_Project.Models.DB;
using IMDB_API_Project.Models.Requests;
using IMDB_API_Project.Models.Responses;
using System.Collections.Generic;

namespace IMDB_API_Project.Services
{
    public interface IProducersService
    {
        int Add(ProducerRequest producerRequest);
        ProducerResponse Get(int producerId);
        List<ProducerResponse> Get();
        void Update(int producerId, ProducerRequest producerRequest);
        void Delete(int producerId);
        bool ValidateId(int producerId);
    }
}