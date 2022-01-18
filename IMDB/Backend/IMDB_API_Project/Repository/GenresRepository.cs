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
    public class GenresRepository : GenericRepository<Genre>, IGenresRepository
    {
        private readonly ConnectionString _connectionString;

        public GenresRepository(IOptions<ConnectionString> options) : base(options)
        {
            _connectionString = options.Value;
        }

        public int Create(Genre genre)
        {
            string query = @"INSERT INTO dbo.Genres ([Name])
                           VALUES (@Name);

                           SELECT CAST(SCOPE_IDENTITY() AS INT);";
            var value = new
            {
                genre.Name
            };
            var genreId = Create(query, value);
            return genreId;
        }

        public IEnumerable<Genre> Get()
        {
            string query = @"SELECT [Id]
	                                ,[Name]
                           FROM [dbo].Genres;";
            var genres = Get(query);
            return genres;
        }

        public Genre Get(int genreId)
        {
            string query = @"SELECT [Id]
	                                ,[Name]
                           FROM [dbo].Genres
                           WHERE [Id] = @genreId;";
            var value = new
            {
                genreId
            };
            var genre = Get(query, value).FirstOrDefault();
            return genre;
        }

        public void Update(int genreId, Genre genre)
        {
            string query = @"UPDATE [dbo].Genres 
                           SET [Name]=@Name  
                           WHERE [Id]=@genreId;";
            var value = new
            {
                genre.Name,
                genreId
            };
            Update(query, value);
        }

        public void Delete(int genreId)
        {
            string query = @"DELETE
                           FROM GenresMoviesMapping 
                           WHERE [GenreId]=@genreId;

                           DELETE 
                           FROM [dbo].Genres 
                           WHERE [Id]=@genreId;";
            var value = new
            {
                genreId
            };
            Delete(query, value);
        }

        public IEnumerable<Genre> GetByMovieId(int movieId)
        {
            using (var connection = new SqlConnection(_connectionString.IMDBDB))
            {
                string query = @"SELECT G.[Id]
                                        ,G.[Name]
                                FROM Movies M 
                                INNER JOIN GenresMoviesMapping GMM ON M.[Id]=GMM.[MovieId]
                                INNER JOIN Genres G ON GMM.[GenreId]=G.[Id]
                                WHERE GMM.[MovieId]=@movieId;";
                var value = new
                {
                    movieId
                };
                var genres = connection.Query<Genre>(query, value);
                return genres;
            }
        }

        public IEnumerable<Genre> Get(List<int> genresIds)
        {
            using (var connection = new SqlConnection(_connectionString.IMDBDB))
            {
                string query = @"SELECT [Id]
                                    ,[Name]
                               FROM[dbo].Genres
                               WHERE Id IN @genresIds;";
                var value = new
                {
                    genresIds
                };
                var genres = connection.Query<Genre>(query, value);
                return genres;
            }
        }
    }
}