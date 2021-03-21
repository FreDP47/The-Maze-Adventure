namespace TheMazeAdventure.Core.Models
{
    public class Maze
    {
        public Maze(Room[,] layout, int entryRoomId)
        {
            Layout = layout;
            EntryRoomId = entryRoomId;
        }

        public Room[,] Layout { get; }
        public int EntryRoomId { get; }
    }
}
