using IMDB_API_Project.Models.DB;
using IMDB_API_Project.Models.Requests;
using IMDB_API_Project.Models.Responses;
using System.Collections.Generic;

namespace IMDB_API_Project.Services
{
    public interface IGenresService
    {
        int Add(GenreRequest genreRequest);
        GenreResponse Get(int genreId);
        List<GenreResponse> Get();
        List<GenreResponse> Get(List<int> genresIds);
        void Update(int genreId, GenreRequest genreRequest);
        void Delete(int genreId);
        bool ValidateId(int genreId);
        List<GenreResponse> GetByMovieId(int movieId);
    }
}