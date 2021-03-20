namespace TheMazeAdventure.Core.Models
{
    public class Maze
    {
        public Maze(Room[,] layout, Room entryPoint)
        {
            Layout = layout;
            EntryPoint = entryPoint;
        }

        public Room[,] Layout { get; }
        public Room EntryPoint { get; }
        
    }
}
