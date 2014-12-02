using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Web.DI;

namespace Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = CreateWindsorContainer();
            UseCastleToResolveAPIControllers(container);
            UseJsonOnly();
        }

        private IWindsorContainer CreateWindsorContainer()
        {
            var container = new WindsorContainer();
            container.Register(
                Component
                    .For<IWindsorContainer>()
                    .Instance(container),
                Types
                    .FromThisAssembly()
                    .BasedOn<ApiController>()
                    .LifestyleTransient()
            );

            container.Install(FromAssembly.This());

            return container;
        }

        private void UseCastleToResolveAPIControllers(IWindsorContainer container)
        {
            var activator = new WindsorHttpControllerActivator(container);
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), activator);
        }

        private void UseJsonOnly()
        {
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings =
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
        }
    }
}
