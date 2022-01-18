using IMDB_API_Project.Models.DB;
using IMDB_API_Project.Models.Requests;
using IMDB_API_Project.Models.Responses;
using System.Collections.Generic;

namespace IMDB_API_Project.Services
{
    public interface IMoviesService
    {
        int Add(MovieRequest movieRequest);
        List<MovieResponse> Get();
        MovieResponse Get(int movieId);
        void Update(int movieId, MovieRequest movieRequest);
        void Delete(int movieId);
        bool ValidateId(int movieId);
        ImageResponse UploadImage(ImageRequest imageRequest);
    }
}