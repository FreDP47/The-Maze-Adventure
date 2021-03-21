namespace TheMazeAdventure.Core.Models
{
    public class Room : Dimension
    {
        public Room(RoomType type, int id, int row, int column) : base(row, column)
        {
            Id = id;
            Type = type;
        }

        public int Id { get; }
        public RoomType Type { get; }
    }
}
