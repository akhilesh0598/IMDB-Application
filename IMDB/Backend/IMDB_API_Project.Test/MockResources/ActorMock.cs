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
    public class ActorMock
    {
        public static readonly Mock<IActorsRepository> ActorRepositoryMock = new Mock<IActorsRepository>();

        private static readonly IEnumerable<Actor> ListOfActors = new List<Actor>
        {
            new Actor
            {
                Id = 1,
                Name = "A1",
                Bio = "xyz",
                DOB = Convert.ToDateTime("03/07/2000"),
                Gender="Male"
            },
            new Actor
            {
                Id = 2,
                Name = "A2",
                Bio = "xyz",
                DOB = Convert.ToDateTime("03/07/2001"),
                Gender="Male"
            }
        };

        private static readonly IEnumerable<Actor> ListOfActors2 = new List<Actor> { 
            new Actor
            {
                Name = "A1",
                Bio = "xyz",
                DOB = Convert.ToDateTime("03/07/2000"),
                Gender="Male"
            },
            new Actor
            {
                Name = "A2",
                Bio = "xyz",
                DOB = Convert.ToDateTime("03/07/2000"),
                Gender="Male"
            },
        };

        public static void MockResouces()
        {
            ActorRepositoryMock.Setup(x => x.Get()).Returns(ListOfActors);
            ActorRepositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).Returns((int actorId) =>
            {
                return ListOfActors.FirstOrDefault(x => x.Id == actorId);
            });
            ActorRepositoryMock.Setup(x => x.Create(It.IsAny<Actor>())).Returns((Actor actor) =>
            {
                return ListOfActors2.Where(x => x.Name == actor.Name && x.Bio == actor.Bio && x.DOB == actor.DOB && x.Gender == actor.Gender).Select(y => 1).FirstOrDefault();
            });
            ActorRepositoryMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<Actor>()));
            ActorRepositoryMock.Setup(x => x.Delete(It.IsAny<int>())) ;
        }
    }
}
