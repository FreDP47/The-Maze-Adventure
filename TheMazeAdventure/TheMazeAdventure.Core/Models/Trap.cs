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

        public string Name { get; }
        public string TrapTriggerMessage { get; }
        public int ChanceOfInjuryInPercentage { get; }
    }
}
