
namespace WindowExplore.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using AutoMapper;
    using Interfaces;
    using Services;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;

    public static class ComponentsRegistration
    {
        public static void RegisterComponents()
        {
            var container = new Container();
            container.Register<IManagementService, ManagementService>();
            container.RegisterSingleton(typeof(IMapper), MapperConfig.CreateMapper());
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}