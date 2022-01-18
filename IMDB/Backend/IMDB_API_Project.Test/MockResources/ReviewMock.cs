using IMDB_API_Project.Exceptions;
using IMDB_API_Project.ImageUploaderFile;
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
    public class ReviewMock
    {
        public static readonly Mock<IMoviesRepository> MovieRepositoryMock = new Mock<IMoviesRepository>();
        public static readonly Mock<IReviewsRepository> ReviewRepositoryMock = new Mock<IReviewsRepository>();
        public static readonly Mock<IActorsRepository> ActorRepositoryMock = new Mock<IActorsRepository>();
        public static readonly Mock<IGenresRepository> GenreRepositoryMock = new Mock<IGenresRepository>();
        public static readonly Mock<IProducersRepository> ProducerRepositoryMock = new Mock<IProducersRepository>();

        private static readonly IEnumerable<Review> ListOfReviews = new List<Review>
        {
            new Review
            {
                Id = 1,
                Message = "R1",
                MovieId=1
            },
            new Review
            {
                Id = 2,
                Message = "R2",
                MovieId=1
            }
        };

        private static readonly IEnumerable<Review> ListOfReviews2 = new List<Review> {
            new Review
            {
                Message = "R1",
                MovieId=1
            },
            new Review
            {
                Message = "R2",
                MovieId=1
            },
        };

        private static readonly IEnumerable<Movie> ListOfMovies = new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Name = "M1",
                ProducerId=1,
            },
            new Movie
            {
                Id = 2,
                Name = "M2",
                ProducerId=1,
            }
        };


        private static readonly IEnumerable<Actor> ListOfActors = new List<Actor>
        {
            new Actor
            {
                Id = 1,
                Name = "A1",
            },
            new Actor
            {
                Id = 2,
                Name = "A2",
            }
        };

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

        private static readonly IEnumerable<Producer> ListOfProducers = new List<Producer>
        {
            new Producer
            {
                Id = 1,
                Name = "P1",
            },
            new Producer
            {
                Id = 2,
                Name = "P2",
            }
        };

        public static void MockResources()
        {
            //actorRepositoryMock
            ActorRepositoryMock.Setup(x => x.Get()).Returns(ListOfActors);
            ActorRepositoryMock.Setup(x => x.Get(It.IsAny<List<int>>())).Returns((List<int> actorsIds) =>
            {
                return ListOfActors.Where(x => actorsIds.Contains(x.Id));
            });
            ActorRepositoryMock.Setup(x => x.GetByMovieId(It.IsAny<int>())).Returns((int movieId) =>
            {
                if (movieId == 1)
                    return ListOfActors;
                else
                    return new List<Actor>() { };
            });

            //genreRepositoryMock
            GenreRepositoryMock.Setup(x => x.Get()).Returns(ListOfGenres);
            GenreRepositoryMock.Setup(x => x.Get(It.IsAny<List<int>>())).Returns((List<int> genresIds) =>
            {
                return ListOfGenres.Where(x => genresIds.Contains(x.Id));
            });
            GenreRepositoryMock.Setup(x => x.GetByMovieId(It.IsAny<int>())).Returns((int movieId) =>
            {
                if (movieId == 1)
                    return ListOfGenres;
                return new List<Genre>() { };
            });

            //producerRepositoryMock
            ProducerRepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns((int producerId) =>
            {
                return ListOfProducers.Where(y => y.Id == producerId).FirstOrDefault();
            });

            //movieRepositoryMock
            MovieRepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns((int movieId) =>
            {
                return ListOfMovies.Where(y => y.Id == movieId).FirstOrDefault();
            });

            //ReviewRepositoryMock
            ReviewRepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns((int movieId) =>
            {
                return ListOfReviews.Where(x => x.MovieId == movieId);
            });
            ReviewRepositoryMock.Setup(repo => repo.Get(It.IsAny<int>(), It.IsAny<int>())).Returns((int movieId, int reviewId) =>
            {
                return ListOfReviews.Where(x => x.Id == reviewId && x.MovieId == movieId).FirstOrDefault();
            });
            ReviewRepositoryMock.Setup(x => x.Create(It.IsAny<int>(), It.IsAny<Review>())).Returns((int movieId, Review review) =>
            {
                return ListOfReviews2.Where(x => x.Id == review.Id && x.Message == review.Message && x.MovieId == movieId).Select(y => 1).FirstOrDefault();
            });
            ReviewRepositoryMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Review>()));
            ReviewRepositoryMock.Setup(x => x.Delete(It.IsAny<int>(), It.IsAny<int>()));
        }
    }
}