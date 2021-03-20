using System;
using System.Linq;
using System.Threading.Tasks;
using TheMazeAdventure.Core.Models;
using TheMazeAdventure.Core.Repositories;

namespace TheMazeAdventure.Persistence
{
    public class MazeInMemoryRepository : IMazeRepository
    {
        private static Maze _maze;

        public void SaveMaze(Maze maze)
        {
            _maze = maze;
        }

        public string GetEntranceRoomId()
        {
            return _maze.EntryRoomId;
        }
    }
}
