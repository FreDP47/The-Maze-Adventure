using System.Web.Http;
using TheMazeAdventure.API.Controllers;
using TheMazeAdventure.Core.Repositories;
using TheMazeAdventure.Core.Services;
using TheMazeAdventure.Persistence;
using TheMazeAdventure.Services;
using Unity;
using Unity.Lifetime;

namespace TheMazeAdventure.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IMazeRepository, MazeInMemoryRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IMazeService, MazeService>(new TransientLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
