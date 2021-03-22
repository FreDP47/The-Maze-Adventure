using TheMazeAdventure.Core.Models;

namespace TheMazeAdventure.Core.Resources
{
    public class RoomResource
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsTreasureRoom { get; set; }
        public Trap TrapType { get; set; }
    }
}
