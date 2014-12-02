using System;
using System.Configuration;
using System.Data.Entity;
using Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataTests
{
    [Ignore]
    [TestClass]
    public class DbUtilities
    {
        [TestMethod]
        public void DropCreateDatabase()
        {
            var connectionString = ConfigurationManager.AppSettings["connectionString"];
            var context = new TestDbContext(connectionString);

            if (context.Database.Exists())
            {
                context.Database.Delete();
            }
            context.Database.Create();
        }

        [TestMethod]
        public void SeedDatabase()
        {
            
        }
    }

    public class TestDbContext : DbContext
    {
        public TestDbContext(string connectionString)
            : base(connectionString)
        { }

        DbSet<Talk> Talks { get; set; }
        DbSet<Speaker> Speakers { get; set; }
    }
}
