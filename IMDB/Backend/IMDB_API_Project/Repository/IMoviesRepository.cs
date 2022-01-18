using IMDB_API_Project.Models.DB;
using System.Collections.Generic;

namespace IMDB_API_Project.Repository
{
    public interface IMoviesRepository
    {
        int Create(Movie movie, List<int> actorsIds, List<int> genresIds);
        IEnumerable<Movie> Get();
        Movie Get(int movieId);
        void Update(int movieId, Movie movie, List<int> actorsIds, List<int> genresIds);
        void Delete(int movieId);
        IEnumerable<Movie> GetByProducerId(int producerId);
    }
}