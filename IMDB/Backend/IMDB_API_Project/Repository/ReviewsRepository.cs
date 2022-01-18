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
    public class ReviewsRepository : GenericRepository<Review>, IReviewsRepository
    {
        private readonly ConnectionString _connectionString;

        public ReviewsRepository(IOptions<ConnectionString> options) : base(options)
        {
            _connectionString = options.Value;
        }

        public int Create(int movieId, Review review)
        {
            string query = @"INSERT INTO dbo.Reviews (
	                                [Message]
	                                ,[MovieId]
	                        )
                            VALUES (
	                                @Message
	                                ,@MovieId
	                        );
                            SELECT CAST(SCOPE_IDENTITY() AS INT);";
            var value = new
            {
                review.Message,
                review.MovieId
            };
            var reviewId = Create(query, value);
            return reviewId;
        }

        public IEnumerable<Review> Get(int movieId)
        {
            string query = @"SELECT [Id]
                                    ,[Message]
                                    ,[MovieId] 
                            FROM [dbo].Reviews 
                            WHERE [MovieId]=@movieId;";
            var value = new
            {
                movieId
            };
            var reviews = Get(query, value);
            return reviews;
        }

        public Review Get(int movieId, int reviewId)
        {
            string query = @"SELECT [Id]
                                    ,[Message]
                                    ,[MovieId] 
                            FROM [dbo].Reviews 
                            WHERE [MovieId]=@movieId 
                                    AND [Id]=@reviewId;";
            var value = new
            {
                movieId,
                reviewId
            };
            var review = Get(query, value).FirstOrDefault();
            return review;
        }

        public void Update(int movieId, int reviewId, Review review)
        {
            string query = @"UPDATE [dbo].Reviews 
                            SET [Message]=@Message
                                ,[MovieId]=@MovieId 
                            WHERE [Id]=@reviewId;";
            var value = new
            {
                review.Message,
                review.MovieId,
                reviewId
            };
            Update(query, value);
        }

        public void Delete(int movieId, int reviewId)
        {
            string query = @"DELETE 
                            FROM [dbo].Reviews 
                            WHERE [MovieId]=@movieId 
                                    AND [Id]=@reviewId;";
            var value = new
            {
                movieId,
                reviewId
            };
            Delete(query, value);
        }
    }
}