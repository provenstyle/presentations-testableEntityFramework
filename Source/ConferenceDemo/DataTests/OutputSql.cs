using System;
using Data.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataTests
{
    [TestClass]
    public class OutputSql
    {
        [TestMethod]
        public void can_output_sql_for_a_given_query()
        {
            //Arrange
            var dataContext = Helper.RealDataContext();
            var query = new TalksBySpeakerId(7);

            //Act
            var sql = query.OutputSQLStatement(dataContext);
            Console.WriteLine(sql);

            //Assert
            Assert.IsFalse(string.IsNullOrEmpty(sql));
        }
    }
}
