using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMazeAdventure.Core.Models
{
    public class Behaviour
    {
        public Behaviour(bool isTreasureThere)
        {
            IsTreasureThere = isTreasureThere;
        }

        public Trap TrapType { get; set; }
        private bool IsTreasureThere { get; }
    }
}
