﻿using Microsoft.Owin;
using MovieSearch.Web;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace MovieSearch.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
