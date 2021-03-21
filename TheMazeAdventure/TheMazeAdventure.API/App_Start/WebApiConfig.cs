using System.Web.Http;
using AutoMapper;
using TheMazeAdventure.API.Controllers;
using TheMazeAdventure.Core.Mappings;
using TheMazeAdventure.Core.Models;
using TheMazeAdventure.Core.Repositories;
using TheMazeAdventure.Core.Resources;
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

            // Web API routes
            config.MapHttpAttributeRoutes();

        }
    }
}
