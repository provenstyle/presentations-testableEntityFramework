using System;
using System.Collections.Generic;
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
            const int speakerCount = 10;
            var connectionString = ConfigurationManager.AppSettings["connectionString"];
            var context = new TestDbContext(connectionString);

            for (int i = 0; i < speakerCount; i++)
            {
                var speaker = new Speaker
                {
                    Name = Faker.Name.FullName(),
                    Bio = Faker.Lorem.Paragraph(),
                };

                var submittedTalk = new Talk()
                {
                    Abstract = Faker.Lorem.Paragraph(),
                    Title = Faker.Lorem.Sentence(2),
                    Accepted = false,
                    Speakers = new List<Speaker> { speaker }
                };

                var acceptedTalk = new Talk()
                {
                    Abstract = Faker.Lorem.Paragraph(),
                    Title = Faker.Lorem.Sentence(2),
                    Accepted = true,
                    Speakers = new List<Speaker> { speaker }
                };

                context.Speakers.Add(speaker);
                context.Talks.Add(submittedTalk);
                context.Talks.Add(acceptedTalk);    
            }
            

            context.SaveChanges();
        }
    }

    public class TestDbContext : DbContext
    {
        public TestDbContext(string connectionString)
            : base(connectionString)
        { }

        public DbSet<Talk> Talks { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
    }
}
