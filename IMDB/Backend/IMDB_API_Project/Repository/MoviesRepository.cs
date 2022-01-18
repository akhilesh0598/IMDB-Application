using Dapper;
using IMDB_API_Project.Connections;
using IMDB_API_Project.Models.DB;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace IMDB_API_Project.Repository
{
    public class MoviesRepository : GenericRepository<Movie>, IMoviesRepository
    {
        private readonly ConnectionString _connectionString;

        public MoviesRepository(IOptions<ConnectionString> options) : base(options)
        {
            _connectionString = options.Value;
        }

        public int Create(Movie movie, List<int> actorsIds, List<int> genresIds)
        {
            var actorsIdsWithCommaSepereted = string.Join(",", actorsIds);
            var genresIdsWithCommaSepereted = string.Join(",", genresIds);
            int movieId;
            var value = new
            {
                Name = movie.Name,
                YearOfRelease = movie.YearOfRelease,
                Plot = movie.Plot,
                ProducerId = movie.ProducerId,
                ImageUrl = movie.ImageUrl,
                ActorsIds = actorsIdsWithCommaSepereted,
                GenresIds = genresIdsWithCommaSepereted
            };
            using (var connection = new SqlConnection(_connectionString.IMDBDB))
            {
                movieId = connection.Query<int>("csp_CreateMovie", value, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return movieId;
        }

        public IEnumerable<Movie> Get()
        {
            string query = @"SELECT [Id]
	                                ,[Name]
	                                ,[YearOfRelease]
	                                ,[Plot]
	                                ,[ProducerId]
	                                ,[ImageUrl]
                           FROM [dbo].Movies;";
            var movies = Get(query);
            return movies;
        }

        public Movie Get(int movieId)
        {
            string query = @"SELECT [Id]
                                    ,[Name]
                                    ,[YearOfRelease]
                                    ,[Plot]
                                    ,[ProducerId]
                                    ,[ImageUrl] 
                            FROM [dbo].Movies 
                            WHERE [Id]=@movieId;";
            var value = new
            {
                movieId
            };
            var movie = Get(query, value).FirstOrDefault();
            return movie;
        }

        public void Update(int movieId, Movie movie, List<int> actorsIds, List<int> genresIds)
        {
            var actorsIdsWithCommaSepereted = string.Join(",", actorsIds);
            var genresIdsWithCommaSepereted = string.Join(",", genresIds);
            var value = new
            {
                MovieId = movieId,
                Name = movie.Name,
                YearOfRelease = movie.YearOfRelease,
                Plot = movie.Plot,
                ProducerId = movie.ProducerId,
                ImageUrl = movie.ImageUrl,
                ActorsIds = actorsIdsWithCommaSepereted,
                GenresIds = genresIdsWithCommaSepereted
            };
            using (var connection = new SqlConnection(_connectionString.IMDBDB))
            {
                connection.Query("usp_UpdateMovie", value, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int movieId)
        {
            string query = @"DELETE 
                            FROM [dbo].Reviews 
                            WHERE [MovieId]=@movieId;

                            DELETE 
                            FROM ActorsMoviesMapping 
                            WHERE [MovieId]=@movieId;

                            DELETE 
                            FROM GenresMoviesMapping 
                            WHERE [MovieId]=@movieId;

                            DELETE 
                            FROM [dbo].Movies 
                            WHERE [Id]=@movieId;";
            var value = new
            {
                movieId
            };
            Delete(query, value);
        }
        public IEnumerable<Movie> GetByProducerId(int producerId)
        {
            string query = @"SELECT [Id]
	                                ,[Name]
	                                ,[YearOfRelease]
	                                ,[Plot]
	                                ,[ProducerId]
	                                ,[ImageUrl]
                           FROM [dbo].Movies
                            WHERE [ProducerId]=@producerId;";
            var value = new
            {
                producerId
            };
            var movies = Get(query, value);
            return movies;
        }
    }
}
