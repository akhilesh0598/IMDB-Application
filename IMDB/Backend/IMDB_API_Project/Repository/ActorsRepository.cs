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
    public class ActorsRepository : GenericRepository<Actor>, IActorsRepository
    {
        private readonly ConnectionString _connectionString;

        public ActorsRepository(IOptions<ConnectionString> options) : base(options)
        {
            _connectionString = options.Value;
        }

        public int Create(Actor actor)
        {
            string query = @"INSERT INTO dbo.Actors (
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

                           SELECT CAST(SCOPE_IDENTITY() AS INT);";
            var value = new
            {
                actor.Name,
                actor.Bio,
                actor.DOB,
                actor.Gender
            };
            var actorId = Create(query, value);
            return actorId;
        }

        public IEnumerable<Actor> Get()
        {
            string query = @"SELECT [Id]
                                ,[Name]
                                ,[Bio]
                                ,[DOB]
                                ,[Gender]
                            FROM[dbo].Actors; ";
            var actors = Get(query);
            return actors;
        }

        public Actor Get(int actorId)
        {
            string query = @"SELECT [Id]
                                ,[Name]
                                ,[Bio]
                                ,[DOB]
                                ,[Gender]
                            FROM[dbo].Actors
                            WHERE[Id] = @actorId; ";
            var value = new
            {
                actorId
            };
            var actor = Get(query, value).FirstOrDefault();
            return actor;
        }

        public void Update(int actorId, Actor actor)
        {
            string query = @"UPDATE [dbo].Actors
                           SET[Name] = @Name
	                          ,[Bio] = @Bio
	                          ,[DOB] = @DOB
	                          ,[Gender] = @Gender
                           WHERE[Id] = @actorId; ";
            var value = new
            {
                actor.Name,
                actor.Bio,
                actor.DOB,
                actor.Gender,
                actorId
            };
            Update(query, value);
        }

        public void Delete(int actorId)
        {
            string query = @"DELETE
                           FROM ActorsMoviesMapping
                           WHERE [ActorId] = @actorId;
               
                           DELETE
                           FROM[dbo].Actors
                           WHERE[Id] = @actorId;";
            var value = new
            {
                actorId
            };
            Delete(query, value);
        }

        public IEnumerable<Actor> GetByMovieId(int movieId)
        {
            using (var connection = new SqlConnection(_connectionString.IMDBDB))
            {
                string query = @"SELECT A.[Id]
                                        ,A.[Name]
                                        ,A.[Bio]
                                        ,A.[DOB]
                                        ,A.[Gender]
                                FROM Movies M 
                                INNER JOIN ActorsMoviesMapping AMM ON M.[Id]=AMM.[MovieId]
                                INNER JOIN Actors A ON AMM.[ActorId]=A.[Id]
                                WHERE AMM.[MovieId]=@movieId;";
                var value = new
                {
                    movieId
                };
                var actors = connection.Query<Actor>(query, value);
                return actors;
            }
        }

        public IEnumerable<Actor> Get(List<int> actorsIds)
        {
            using (var connection = new SqlConnection(_connectionString.IMDBDB))
            {
                string query = @"SELECT [Id]
                                    ,[Name]
                                    ,[Bio]
                                    ,[DOB]
                                    ,[Gender]
                               FROM[dbo].Actors
                               WHERE Id IN @actorsIds;";
                var value = new
                {
                    actorsIds
                };
                var actors = connection.Query<Actor>(query, value);
                return actors;
            }
        }
    }
}