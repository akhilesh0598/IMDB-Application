using IMDB_API_Project.Models.DB;
using System.Collections.Generic;

namespace IMDB_API_Project.Repository
{
    public interface IProducersRepository
    {
        int Create(Producer producer);
        IEnumerable<Producer> Get();
        Producer Get(int producerId);
        void Update(int producerId, Producer producer);
        void Delete(int producerId);
    }
}