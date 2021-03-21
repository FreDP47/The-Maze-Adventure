using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMazeAdventure.Core.Models;

namespace TheMazeAdventure.Core.Resources
{
    public class RoomResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isTreasureRoom { get; set; }
        public Trap TrapType { get; set; }
    }
}
