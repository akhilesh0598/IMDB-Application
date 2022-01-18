using IMDB_API_Project.Models.DB;
using System.Collections.Generic;

namespace IMDB_API_Project.Repository
{
    public interface IReviewsRepository
    {
        int Create(int movieId, Review review);
        IEnumerable<Review> Get(int movieId);
        Review Get(int movieId, int reviewId);
        void Update(int movieId, int reviewId, Review review);
        void Delete(int movieId, int reviewId);
    }
}