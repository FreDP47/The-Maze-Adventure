namespace TheMazeAdventure.Core.Models
{
    public class Dimension
    {
        public Dimension(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; }
        public int Column { get; }
    }
}
