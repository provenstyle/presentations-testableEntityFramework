using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Queries;
using Data;
using Highway.Data.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataTests
{
    [TestClass]
    public class PerformanceTests
    {
        [TestMethod]
        public void can_performance_test_queries()
        {
            //Arrange
            var dataContext = Helper.RealDataContext();
            var query = new AllTalks();

            //Act
            query.RunPerformanceTest(dataContext, false, 50);

            //Assert
        }
    }
}
