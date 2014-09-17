using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BLL;
using DAL;
using DAL.Contracts;
using DAL.Repositories;
using Ninject;
using Ninject.Web.Common;
using BLL.Contracts;
using BLL.Services;

namespace Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;
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
            _kernel.Bind<MoviesContext>().ToSelf().InRequestScope();
        }
    }
}