namespace TheMazeAdventure.Core.Models
{
    public class Maze
    {
        public Maze(Room[,] layout, long entryRoomId)
        {
            Layout = layout;
            EntryRoomId = entryRoomId;
        }

        public Room[,] Layout { get; }
        public long EntryRoomId { get; }
    }
}
