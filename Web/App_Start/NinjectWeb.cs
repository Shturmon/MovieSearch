using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using MovieSearch.Web;
using Ninject.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWeb), "Start")]

namespace MovieSearch.Web
{
    public static class NinjectWeb 
    {
        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
        }
    }
}
