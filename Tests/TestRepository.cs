using System;
using System.Linq;
using BLL;
using DAL;
using DAL.Models;
using DAL.Repositories;
using NUnit.Framework;

namespace Tests
{
    public class TestRepository : TestsBase
    {
        [Test]
        public void TestInsert()
        {
            var repo = new CareerRepository(new MoviesContext());
            var career = new Career { Id = Guid.NewGuid(), Title = "testInsertCareer" };
            repo.Insert(career);
            repo.Save();

            var sameCareer = repo.GetById(career.Id);
            Assert.AreEqual(career.Title, sameCareer.Title);

            repo.Delete(career);
            repo.Save();
        }

        [Test]
        public void TestDelete()
        {
            var repo = new CareerRepository(new MoviesContext());
            var career = new Career { Id = Guid.NewGuid(), Title = "testDeleteCareer" };
            repo.Insert(career);
            repo.Save();

            repo.Delete(career.Id);
            repo.Save();

            var sameCareer = repo.GetById(career.Id);
            Assert.IsNull(sameCareer);
        }

        [Test]
        public void TestUpdate()
        {
            var repo = new CareerRepository(new MoviesContext());
            var career = new Career { Id = Guid.NewGuid(), Title = "testUpdateCareer" };
            repo.Insert(career);
            repo.Save();

            career.Title = "UpdatedCareer";
            repo.Update(career);
            repo.Save();
            var sameCareer = repo.GetById(career.Id);
            Assert.AreEqual(career.Title, sameCareer.Title);

            repo.Delete(career);
            repo.Save();
        }

        [Test]
        public void TestGet()
        {
            var repo = new CareerRepository(new MoviesContext());
            Career[] careers = new Career[5];
            for (int i = 0; i < 5; i++)
            {
                careers[i] = new Career { Id = Guid.NewGuid(), Title = "testGetCareer" + i };
                repo.Insert(careers[i]);
            }
            repo.Save();

            var listOfCareers = repo.Get(c => c.Title.StartsWith("testGetCareer"));
            int j = 0;

            Assert.AreEqual(listOfCareers.Count(), 5);
            for (int i = 0; i < 5; i++)
            {
                Assert.NotNull(listOfCareers.SingleOrDefault(c => c.Title == careers[j].Title));
            }

            for (int i = 0; i < 5; i++)
            {
                repo.Delete(careers[i]);
            }
            repo.Save();
        }
    }
}
