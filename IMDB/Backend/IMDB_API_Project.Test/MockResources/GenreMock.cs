using IMDB_API_Project.Exceptions;
using IMDB_API_Project.Models.DB;
using IMDB_API_Project.Models.Requests;
using IMDB_API_Project.Models.Responses;
using IMDB_API_Project.Repository;
using IMDB_API_Project.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB_API_Project.Test.MockResources
{
    public class GenreMock
    {
        public static readonly Mock<IGenresRepository> GenreRepositoryMock = new Mock<IGenresRepository>();

        private static readonly IEnumerable<Genre> ListOfGenres = new List<Genre>
        {
            new Genre
            {
                Id = 1,
                Name = "G1",               
            },
            new Genre
            {
                Id = 2,
                Name = "G2",
            }
        };

        private static readonly IEnumerable<Genre> ListOfGenres2 = new List<Genre> {
            new Genre
            {
                Name = "G1"
            },
            new Genre
            {
                Name = "G2",
            }
        };

        public static void MockResources()
        {
            GenreRepositoryMock.Setup(x => x.Get()).Returns(ListOfGenres);
            GenreRepositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns((int genreId) =>
            {
                return ListOfGenres.Where(x => x.Id == genreId).FirstOrDefault();
            });
            GenreRepositoryMock.Setup(x => x.Create(It.IsAny<Genre>())).Returns((Genre genre) =>
            {
                return ListOfGenres2.Where(x => x.Id == genre.Id && x.Name == genre.Name).Select(y => 1).FirstOrDefault();
            });
            GenreRepositoryMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<Genre>()));
            GenreRepositoryMock.Setup(x => x.Delete(It.IsAny<int>()));
        }
    }
}
