using AutoMapper;
using TheMazeAdventure.Core.Models;
using TheMazeAdventure.Core.Resources;

namespace TheMazeAdventure.Core.Mappings
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Maze, MazeResource>();
        }
    }
}
