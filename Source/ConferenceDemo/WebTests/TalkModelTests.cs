using System.Collections.Generic;
using System.Linq;
using Data.Entities;
using Data.Queries;
using Highway.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Web.Models;

namespace WebTests
{
    [TestClass]
    public class TalkModelTests
    {
        [TestMethod]
        public void returns_accepted_and_non_accepted_talks()
        {
            //Arrange
            var repo = new Mock<IRepository>();
            repo
                .Setup(x => x.Find(It.IsAny<TalksBySpeakerId>()))
                .Returns(new List<Talk>
                {
                    new Talk{Accepted = true},
                    new Talk{Accepted = false}
                });

            var model = new TalkModel(repo.Object);

            //Act
            var talks = model.GetTalks(1);

            //Assert
            Assert.AreEqual(1, talks.AcceptedTalks.Count());
            Assert.AreEqual(1, talks.SubmittedTalks.Count());
        }
    }
}
