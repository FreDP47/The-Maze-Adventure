namespace TheMazeAdventure.Core.Models
{
    public class Behaviour
    {
        public Behaviour(bool isTreasureThere)
        {
            IsTreasureThere = isTreasureThere;
        }

        public Trap TrapType { get; set; }
        public bool IsTreasureThere { get; }
    }
}
