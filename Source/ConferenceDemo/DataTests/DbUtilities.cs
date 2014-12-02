using System;
using System.Collections.Generic;
using System.Configuration;
using Data;
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
            var context = new ConferenceDemoDbContext(connectionString);

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
            var context = new ConferenceDemoDbContext(connectionString);

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
                    Speaker = speaker
                };

                var acceptedTalk = new Talk()
                {
                    Abstract = Faker.Lorem.Paragraph(),
                    Title = Faker.Lorem.Sentence(2),
                    Accepted = true,
                    Speaker = speaker
                };

                context.Speakers.Add(speaker);
                context.Talks.Add(submittedTalk);
                context.Talks.Add(acceptedTalk);    
            }
            

            context.SaveChanges();
        }
    }
}
