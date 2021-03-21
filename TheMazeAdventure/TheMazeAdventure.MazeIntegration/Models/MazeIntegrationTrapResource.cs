using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMazeAdventure.MazeIntegration.Models
{
    public class MazeIntegrationTrapResource
    {
        public string Name { get; set; }
        public string TrapTriggerMessage { get; set; }
        public int ChanceOfInjuryInPercentage { get; set; }
    }
}
