using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMazeAdventure.Core.Models
{
    public class Trap
    {
        public Trap(string name, string trapTriggerMessage, int chanceOfInjuryInPercentage)
        {
            Name = name;
            TrapTriggerMessage = trapTriggerMessage;
            ChanceOfInjuryInPercentage = chanceOfInjuryInPercentage;
        }

        private string Name { get; }
        private string TrapTriggerMessage { get; }
        private int ChanceOfInjuryInPercentage { get; }
    }
}
