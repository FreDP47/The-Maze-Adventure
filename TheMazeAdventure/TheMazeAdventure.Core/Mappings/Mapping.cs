using AutoMapper;
using TheMazeAdventure.Core.Models;
using TheMazeAdventure.Core.Resources;

namespace TheMazeAdventure.Core.Mappings
{
    public class Mapping
    {
        public MapperConfiguration Configuration { get; }
        public Mapping()
        {
            Configuration = new MapperConfiguration(cfg => cfg.CreateMap<Maze, MazeResource>());
        }
    }
}
