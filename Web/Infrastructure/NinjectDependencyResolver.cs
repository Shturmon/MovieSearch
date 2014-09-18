using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MovieSearch.Data;
using MovieSearch.Data.Contracts;
using MovieSearch.Data.Contracts.Repositories;
using MovieSearch.Data.DAL.Context;
using MovieSearch.Data.DAL.Repositories;
using MovieSearch.Logic.BLL.Services;
using MovieSearch.Logic.Contracts;
using MovieSearch.Logic.Contracts.Services;
using Ninject;
using Ninject.Web.Common;

namespace MovieSearch.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;
        public NinjectDependencyResolver()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            _kernel.Bind<IGenreRepository>().To<GenreRepository>().InRequestScope();
            _kernel.Bind<IGenreService>().To<GenreService>().InRequestScope();
            _kernel.Bind<ICountryRepository>().To<CountryRepository>().InRequestScope();
            _kernel.Bind<ICountryService>().To<CountryService>().InRequestScope();
            _kernel.Bind<ICareerRepository>().To<CareerRepository>().InRequestScope();
            _kernel.Bind<ICareerService>().To<CareerService>().InRequestScope();
            _kernel.Bind<IPeopleRepository>().To<PeopleRepository>().InRequestScope();
            _kernel.Bind<IPeopleService>().To<PeopleService>().InRequestScope();
            _kernel.Bind<IMovieRepository>().To<MovieRepository>().InRequestScope();
            _kernel.Bind<IMovieService>().To<MovieService>().InRequestScope();
            _kernel.Bind<IUserCommentRepository>().To<UserCommentRepository>().InRequestScope();
            _kernel.Bind<IUserCommentService>().To<UserCommentService>().InRequestScope();
            _kernel.Bind<IRatingRepository>().To<RatingRepository>().InRequestScope();
            _kernel.Bind<IRatingService>().To<RatingService>().InRequestScope();
            _kernel.Bind<MoviesDbContext>().ToSelf().InRequestScope();
        }
    }
}