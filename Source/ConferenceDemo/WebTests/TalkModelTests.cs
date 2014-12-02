using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using Data;
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
                }.AsQueryable());

            var model = new TalkModel(repo.Object);

            //Act
            var talks = model.GetTalks(1);

            //Assert
            Assert.AreEqual(DynamicEnumerable.Count(talks.AcceptedTalks), 1);
            Assert.AreEqual(DynamicEnumerable.Count(talks.SubmittedTalks), 1);
        }
    }
}
