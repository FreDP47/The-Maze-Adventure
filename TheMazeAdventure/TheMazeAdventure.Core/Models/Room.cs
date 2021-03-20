using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMazeAdventure.Core.Models
{
    public class Room
    {
        public Room(RoomType type)
        {
            Type = type;
            Description = type.Description;
        }

        private RoomType Type { get; }
        private string Description { get; }
    }
}
