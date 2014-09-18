using System;
using MovieSearch.Data;
using MovieSearch.Data.DAL.Context;
using MovieSearch.Data.DAL.Repositories;
using MovieSearch.Data.Models;
using MovieSearch.Logic.BLL.Services;
using MovieSearch.Logic.Contracts;
using MovieSearch.Logic.Contracts.Services;
using NUnit.Framework;

namespace MovieSearch.Tests
{
    public class TestService : TestsBase
    {
        [Test]
        public void TestAdd()
        {
            ICareerService service = new CareerService(new CareerRepository(new MoviesDbContext()));
            var career = new Career { Id = Guid.NewGuid(), Title = "testInsertCareer" };
            service.AddCareer(career);

            var sameCareer = service.GetCareerById(career.Id);
            Assert.AreSame(career, sameCareer);

            service.Delete(career.Id);
        }

        [Test]
        public void TestDelete()
        {
            ICareerService service = new CareerService(new CareerRepository(new MoviesDbContext()));
            var career = new Career { Id = Guid.NewGuid(), Title = "testDeleteCareer" };
            service.AddCareer(career);

            service.Delete(career.Id);

            var sameCareer = service.GetCareerById(career.Id);
            Assert.IsNull(sameCareer);
        }

        [Test]
        public void TestUpdate()
        {
            ICareerService service = new CareerService(new CareerRepository(new MoviesDbContext()));
            var career = new Career { Id = Guid.NewGuid(), Title = "testUpdateCareer" };
            service.AddCareer(career);

            career.Title = "UpdatedCareer";
            service.Edit(career);
            var sameCareer = service.GetCareerById(career.Id);
            Assert.AreSame(career.Title, sameCareer.Title);

            service.Delete(career.Id);
        }

        [Test]
        public void TestGetByTitle()
        {
            ICareerService service = new CareerService(new CareerRepository(new MoviesDbContext()));
            var career = new Career { Id = Guid.NewGuid(), Title = "testGetByTitleCareer" };
            service.AddCareer(career);

            var sameCareer = service.GetCareerByTitle(career.Title);
            Assert.AreSame(career.Title, sameCareer.Title);

            service.Delete(career.Id);
        }
    }
}
