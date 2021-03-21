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

        public Task SaveMazeAsync(Maze maze)
        {
            return Task.Run(() => { _maze = maze; });
        }

        public long GetEntranceRoomId()
        {
            return _maze.EntryRoomId;
        }
    }
}
