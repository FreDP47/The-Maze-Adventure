using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMazeAdventure.Core.Models
{
    public class RoomType
    {
        public RoomType(string name)
        {
            Name = name;
        }

        private string Name { get; }
        public string Description { get; set; }
        public Behaviour BehaviourType { get; set; }
    }
}
