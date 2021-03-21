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
            Configuration = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Maze, MazeResource>();
                    cfg.CreateMap<Room, RoomResource>()
                        .ForMember(dest => 
                            dest.Name, opt => 
                            opt.MapFrom(src => src.Type.Name))
                        .ForMember(dest =>
                            dest.TrapType, opt =>
                            opt.MapFrom(src => src.Type.BehaviourType.TrapType))
                        .ForMember(dest =>
                            dest.isTreasureRoom, opt =>
                            opt.MapFrom(src => src.Type.BehaviourType.IsTreasureThere));
                });
        }
    }
}
