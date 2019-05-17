using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Fanex.Data.Repository;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using WebAPIDemo.Interfaces;
using WebAPIDemo.Services;

namespace WebAPIDemo.App_Start
{
    public class ComponentsRegistration
    {
        public static void RegisterComponents()
        {
            var container = new Container();
            container.Register<IDynamicRepository, DynamicRepository>();
            container.Register<ITournamentService, TournamentService>();
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}