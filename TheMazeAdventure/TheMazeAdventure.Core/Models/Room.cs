namespace TheMazeAdventure.Core.Models
{
    public class Room
    {
        public Room(RoomType type, int id, string description)
        {
            Id = id;
            Type = type;
            Description = description;
        }

        public int Id { get; }
        public RoomType Type { get; }
        public string Description { get; }
    }
}
