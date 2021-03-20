namespace TheMazeAdventure.Core.Models
{
    public class Maze
    {
        public Maze(Room[,] layout, string entryRoomId)
        {
            Layout = layout;
            EntryRoomId = entryRoomId;
        }

        public Room[,] Layout { get; }
        public string EntryRoomId { get; }
        
    }
}
