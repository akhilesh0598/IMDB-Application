using Dapper;
using IMDB_API_Project.Connections;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace IMDB_API_Project.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IOptions<ConnectionString> _options;

        public GenericRepository(IOptions<ConnectionString> options)
        {
            _options = options;
        }

        public int Create(string query, Object value)
        {
            using (var connection = new SqlConnection(_options.Value.IMDBDB))
            {
                var id = connection.Query<int>(query, value).FirstOrDefault();
                return id;
            }
        }

        public IEnumerable<T> Get(string query)
        {
            using (var connection = new SqlConnection(_options.Value.IMDBDB))
            {
                var value = connection.Query<T>(query);
                return value;
            }
        }

        public IEnumerable<T> Get(string query, Object param)
        {
            using (var connection = new SqlConnection(_options.Value.IMDBDB))
            {
                var value = connection.Query<T>(query, param);
                return value;
            }
        }

        public void Update(string query, object param)
        {
            using (var connection = new SqlConnection(_options.Value.IMDBDB))
            {
                connection.Execute(query, param);
            }
        }

        public void Delete(string query, object param)
        {
            using (var connection = new SqlConnection(_options.Value.IMDBDB))
            {
                connection.Execute(query, param);
            }
        }
    }
}