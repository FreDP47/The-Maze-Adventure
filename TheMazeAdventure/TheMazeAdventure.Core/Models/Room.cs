namespace TheMazeAdventure.Core.Models
{
    public class Room
    {
        public Room(RoomType type, long id, string description, long row, long column)
        {
            Id = id;
            Type = type;
            Description = description;
            Row = row;
            Column = column;
        }

        public long Id { get; }
        public RoomType Type { get; }
        public string Description { get; }
        public long Row { get; }
        public long Column { get; }
    }
}
