using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMazeAdventure.Core.Models;
using TheMazeAdventure.Core.Repositories;

namespace TheMazeAdventure.Persistence
{
    public class RoomTypeInMemoryRepository : IRoomTypeRepository
    {
        private List<RoomType> _roomTypes = new List<RoomType>()
        {
            new RoomType("Empty Room")
            {
                Description = "You see an empty room",
                BehaviourType = null
            },
            new RoomType("Treasure Room")
            {
                Description = "You see the treasure and your eyes light up",
                BehaviourType = new Behaviour(true)
            },
            new RoomType("Marsh")
            {
                Description = "You are looking at a heap of leaves and feel slightly elated.",
                BehaviourType = new Behaviour(false)
                {
                    TrapType = 
                        new Trap
                        (
                        "marshes", " But you immediately begin to sink", 30
                        )
                }
            },
            new RoomType("Desert")
            {
                Description = "You are looking at a desert with heaps of sands and feel thirsty.",
                BehaviourType = new Behaviour(false)
                {
                    TrapType =
                        new Trap
                        (
                            "marshes", " But you immediately begin to dehydrate", 20
                        )
                }
            }
        };
        public async Task<IEnumerable<RoomType>> GetAllRoomTypesAsync()
        {
            return await Task.Run(() => _roomTypes);
        }
    }
}
