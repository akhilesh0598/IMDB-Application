using IMDB_API_Project.Models.DB;
using IMDB_API_Project.Models.Requests;
using IMDB_API_Project.Models.Responses;
using System.Collections.Generic;

namespace IMDB_API_Project.Services
{
    public interface IReviewsService
    {
        int Add(int movieId, ReviewRequest reviewRequest);
        ReviewResponse Get(int movieId, int reviewId);
        List<ReviewResponse> Get(int movieId);
        void Update(int movieId, int reviewId, ReviewRequest review);
        void Delete(int movieId, int reviewId);
        bool ValidateId(int movieId, int reviewId);
    }
}