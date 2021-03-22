using System.Threading.Tasks;
using TheMazeAdventure.Core.Communication;
using TheMazeAdventure.Core.Models;
using TheMazeAdventure.Core.Repositories;

namespace TheMazeAdventure.Persistence
{
    public class MazeInMemoryRepository : IMazeRepository
    {
        private static Maze _maze;

        public async Task<MazeResponse> SaveMazeAsync(Maze maze)
        {
            await Task.Run(() => { _maze = maze; });
            return new MazeResponse(_maze);
        }

        public int GetEntranceRoomId()
        {
            return _maze.EntryRoomId;
        }

        public async Task<RoomResponse> GetRoomByIdAsync(int roomId)
        {
            var size = _maze.Layout.GetLength(0);
            var layout = _maze.Layout;
            Room room = null;
            await Task.Run(() =>
            {
                for (var i = 0; i < size; i++)
                {
                    for (var j = 0; j < size; j++)
                    {
                        if (layout[i, j].Id != roomId) continue;
                        room = layout[i, j];
                        break;
                    }
                    if (room != null)
                        break;
                }
            });

            return new RoomResponse(room);
        }
    }
}
