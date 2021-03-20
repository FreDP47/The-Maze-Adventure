using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMazeAdventure.Core.Models
{
    public class Maze
    {
        public Maze(Room[,] layout, Room entryPoint)
        {
            Layout = layout;
            EntryPoint = entryPoint;
        }

        private Room[,] Layout { get; }
        private Room EntryPoint { get; }
        
    }
}
