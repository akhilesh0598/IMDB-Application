
using IMDB_API_Project.Models.DB;
using System.Collections.Generic;

namespace IMDB_API_Project.Repository
{
    public interface IGenresRepository
    {
        int Create(Genre genre);
        IEnumerable<Genre> Get();
        Genre Get(int genreId);
        void Update(int genreId, Genre genre);
        void Delete(int genreId);
        IEnumerable<Genre> GetByMovieId(int movieId);
        IEnumerable<Genre> Get(List<int> genresIds);
    }
}