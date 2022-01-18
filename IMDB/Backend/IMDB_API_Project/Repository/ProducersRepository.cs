using Dapper;
using IMDB_API_Project.Connections;
using IMDB_API_Project.Models.DB;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace IMDB_API_Project.Repository
{
    public class ProducersRepository : GenericRepository<Producer>, IProducersRepository
    {
        private readonly ConnectionString _connectionString;

        public ProducersRepository(IOptions<ConnectionString> options) : base(options)
        {
            _connectionString = options.Value;
        }

        public int Create(Producer producer)
        {
            string query = @"INSERT 
                            INTO dbo.Producers
                                    (
                                    [Name]
                                    ,[Bio]
                                    ,[DOB]
                                    ,[Gender]
                                    ) 
                            VALUES (
                                    @Name
                                    ,@Bio
                                    ,@DOB
                                    ,@Gender
                                    );
                            SELECT CAST(SCOPE_IDENTITY() as int);";
            var value = new
            {
                producer.Name,
                producer.Bio,
                producer.DOB,
                producer.Gender
            };
            var producerId = Create(query, value);
            return producerId;
        }

        public IEnumerable<Producer> Get()
        {
            string query = @"SELECT [Id]
                                    ,[Name]
                                    ,[Bio]
                                    ,[DOB]
                                    ,[Gender] 
                            FROM [dbo].Producers;";
            var producers = Get(query);
            return producers;
        }

        public Producer Get(int producerId)
        {
            string query = @"SELECT [Id]
                                    ,[Name]
                                    ,[Bio]
                                    ,[DOB]
                                    ,[Gender] 
                            FROM [dbo].Producers 
                            WHERE [Id]=@producerId;";
            var value = new
            {
                producerId
            };
            var producer = Get(query, value).FirstOrDefault();
            return producer;
        }

        public void Update(int producerId, Producer producer)
        {
            string query = @"UPDATE [dbo].Producers 
                            SET [Name]=@Name
                                ,[Bio]=@Bio
                                ,[DOB]=@DOB
                                ,[Gender]=@Gender 
                            WHERE [Id]=@producerId;";
            var value = new
            {
                producer.Name,
                producer.Bio,
                producer.DOB,
                producer.Gender,
                producerId
            };
            Update(query, value);
        }

        public void Delete(int producerId)
        {
            string query = @"DELETE 
                            FROM [dbo].Reviews 
                            WHERE [MovieId] IN (
                            SELECT [Id]
                            FROM [dbo].Movies
                            WHERE [ProducerId]=@producerId);

                            DELETE 
                            FROM ActorsMoviesMapping 
                            WHERE [MovieId] IN (
                            SELECT [Id]
                            FROM [dbo].Movies
                            WHERE [ProducerId]=@producerId);

                            DELETE 
                            FROM GenresMoviesMapping 
                            WHERE [MovieId] IN (
                            SELECT [Id]
                            FROM [dbo].Movies
                            WHERE [ProducerId]=@producerId);

                            DELETE 
                            FROM [dbo].Movies 
                            WHERE [Id] IN (
                            SELECT [Id]
                            FROM [dbo].Movies
                            WHERE [ProducerId]=@producerId);
                            
                            DELETE 
                            FROM [dbo].Producers 
                            WHERE [Id]=@producerId;";
            var value = new
            {
                producerId
            };
            Delete(query, value);
        }
    }
}