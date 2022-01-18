using System;
using System.Collections.Generic;

namespace IMDB_API_Project.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        int Create(string query, object value);
        IEnumerable<T> Get(string query);
        IEnumerable<T> Get(string query, Object param);
        void Update(string query, object param);
        void Delete(string query, object param);
    }
}