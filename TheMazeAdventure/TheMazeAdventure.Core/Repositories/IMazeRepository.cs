using System.Threading.Tasks;
using TheMazeAdventure.Core.Communication;
using TheMazeAdventure.Core.Models;

namespace TheMazeAdventure.Core.Repositories
{
    /// <summary>
    /// Used for updating or getting the maze details which is stored in memory.
    /// </summary>
    public interface IMazeRepository
    {
        /// <summary>
        /// Saves the maze.
        /// </summary>
        /// <param name="maze">maze</param>
        Task<MazeResponse> SaveMazeAsync(Maze maze);

        /// <summary>
        /// Gets the ID Entrance room of the maze
        /// </summary>
        /// <returns></returns>
        int GetEntranceRoomId();

        Task<RoomResponse> GetRoomByIdAsync(int roomId);
    }
}
