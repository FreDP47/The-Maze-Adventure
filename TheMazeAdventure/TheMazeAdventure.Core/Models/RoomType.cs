namespace TheMazeAdventure.Core.Models
{
    public class RoomType
    {
        public RoomType(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public string Description { get; set; }
        public Behaviour BehaviourType { get; set; }
    }
}
