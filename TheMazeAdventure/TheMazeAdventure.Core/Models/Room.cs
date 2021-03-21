namespace TheMazeAdventure.Core.Models
{
    public class Room : Dimension
    {
        public Room(RoomType type, int id, string description, int row, int column) : base(row, column)
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
