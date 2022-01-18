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
    public class ProducerMock
    {
        public static readonly Mock<IProducersRepository> ProducerRepositoryMock = new Mock<IProducersRepository>();
        public static readonly Mock<IMoviesRepository> MovieRepositoryMock = new Mock<IMoviesRepository>();
        public static readonly Mock<IReviewsRepository> ReviewRepositoryMock = new Mock<IReviewsRepository>();

        private static readonly IEnumerable<Producer> ListOfProducers = new List<Producer>
        {
            new Producer
            {
                Id = 1,
                Name = "A1",
                Bio = "xyz",
                DOB = Convert.ToDateTime("03/07/2000"),
                Gender="Male"
            },
            new Producer
            {
                Id = 2,
                Name = "A2",
                Bio = "xyz",
                DOB = Convert.ToDateTime("03/07/2001"),
                Gender="Male"
            }
        };

        private static readonly IEnumerable<Producer> ListOfProducer2 = new List<Producer> {
            new Producer
            {
                Name = "A1",
                Bio = "xyz",
                DOB = Convert.ToDateTime("03/07/2000"),
                Gender="Male"
            },
            new Producer
            {
                Name = "",
                Bio = "xyz",
                DOB = Convert.ToDateTime("03/07/2000"),
                Gender="Male"
            }
        };

        private static readonly IEnumerable<Movie> ListOfMovies = new List<Movie>()
        {
            new Movie()
            {
                Id =1,
                Name="M1",
                ProducerId=1,
            },
            new Movie()
            {
                Id =2,
                Name="M2",
                ProducerId=1,
            }
        };

        public static void MockResources()
        {
            ProducerRepositoryMock.Setup(x => x.Get()).Returns(ListOfProducers);
            ProducerRepositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns((int producerId) =>
            {
                return ListOfProducers.FirstOrDefault(x => x.Id == producerId);
            });
            ProducerRepositoryMock.Setup(x => x.Create(It.IsAny<Producer>())).Returns((Producer producer) =>
            {
                return ListOfProducer2.Where(x => x.Name == producer.Name && x.Bio == producer.Bio && x.DOB == producer.DOB && x.Gender == producer.Gender).Select(y => 1).FirstOrDefault();
            });
            ProducerRepositoryMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<Producer>()));
            ProducerRepositoryMock.Setup(x => x.Delete(It.IsAny<int>()));

            MovieRepositoryMock.Setup(x => x.GetByProducerId(It.IsAny<int>())).Returns((int producerId) =>
            {
                return ListOfMovies.Where(y => y.ProducerId == producerId).ToList();
            });
            MovieRepositoryMock.Setup(x => x.Delete(It.IsAny<int>()));
        }
    }
}
