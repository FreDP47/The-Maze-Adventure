using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMazeAdventure.MazeIntegration.Models
{
    public class MazeIntegrationRoomResource
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsTreasureRoom { get; set; }
        public MazeIntegrationTrapResource TrapType { get; set; }
    }
}
