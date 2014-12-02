using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Highway.Data;
using Highway.Data.Contexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataTests
{
    [TestClass]
    public class QueryTests
    {
        [TestMethod]
        public void can_unit_test_queries()
        {
            //Arrange
            var dataContext = new InMemoryDataContext();
            var speaker = new Speaker {Id = 7};
            dataContext.Add(new Talk {Speaker = speaker, Accepted = true});
            dataContext.Add(new Talk {Speaker = speaker, Accepted = false});

            var query = new AcceptedTalksBySpeaker(7);
            
            //Act
            var acceptedTalks = query.Execute(dataContext);

            //Assert
            Assert.AreEqual(1, acceptedTalks.Count());

        }
    }

    public class AcceptedTalksBySpeaker: Query<Talk>
    {
        public AcceptedTalksBySpeaker(int speakerId)
        {
            ContextQuery = c => c.AsQueryable<Talk>()
                .Where(x => 
                    x.Speaker.Id == speakerId &&
                    x.Accepted);
        }
    }
}
