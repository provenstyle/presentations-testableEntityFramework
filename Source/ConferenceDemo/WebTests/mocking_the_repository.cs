using System;
using System.Collections.Generic;
using System.Linq;
using Data.Entities;
using Data.Queries;
using Highway.Data;
using Highway.Data.Contexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Web.Models;

namespace WebTests
{
    [TestClass]
    public class mocking_the_repository
    {
        [TestMethod]
        public void can_moq_the_repository()
        {
            //Arrange
            var repository = new Mock<IRepository>();
            repository
                .Setup(x => x.Find(It.IsAny<TalksBySpeakerId>()))
                .Returns(new List<Talk>
                {
                    new Talk()
                });
            
            //Act
            var talks = repository.Object.Find(new TalksBySpeakerId(1));

            //Assert
            Assert.AreEqual(talks.Count(), 1);
        }

        [TestMethod]
        public void can_mock_datacontext()
        {
            //Arrange
            var dataContext = new Mock<IDataContext>();
            dataContext.Setup(x => x.AsQueryable<Talk>())
                .Returns(new List<Talk>
                {
                    new Talk(),
                    new Talk()
                }.AsQueryable());

            var repository = new Repository(dataContext.Object);

            //Act
            var talks = repository.Find(new AllTalks());

            //Assert
            Assert.AreEqual(talks.Count(), 2);
        }

        [TestMethod]
        public void can_spy_on_dataContext()
        {
            //Arrange
            var dataContext = new Mock<IDataContext>();
            dataContext.Setup(x => x.AsQueryable<Talk>())
                .Returns(new List<Talk>
                {
                    new Talk(),
                    new Talk()
                }.AsQueryable());

            dataContext
                .Setup(x => x.Commit());

            var repository = new Repository(dataContext.Object);

            //Act
            repository.Context.Commit();

            //Assert
            dataContext.Verify(x=>x.Commit(), Times.Once);
        }

        [TestMethod]
        public void can_use_in_memory_datacontext()
        {
            //Arrange
            var dataContext = new InMemoryDataContext();
            dataContext.Add(new Talk());
            dataContext.Add(new Talk());
            var repository = new Repository(dataContext);

            //Act
            var talks = repository.Find(new AllTalks());

            //Assert
            Assert.AreEqual(talks.Count(), 2);
        }

        [TestMethod]
        public void talkModel_gets_data_from_IRepository()
        {
            //Arrange
            var dataContext = new InMemoryDataContext();
            var speaker = new Speaker {Id = 7};
            dataContext.Add(new Talk {Speaker = speaker, Accepted = false});
            dataContext.Add(new Talk {Speaker = speaker, Accepted = false});
            dataContext.Add(new Talk {Speaker = speaker, Accepted = true});

            var repository = new Repository(dataContext);
            var model = new TalksModel(repository);

            //Act
            var vm = model.GetTalks(7);

            //Assert
            Assert.AreEqual(vm.AcceptedTalks.Count(), 1);
            Assert.AreEqual(vm.SubmittedTalks.Count(), 2);
        }
    }
}
