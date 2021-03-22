using System.Threading.Tasks;
using TheMazeAdventure.Core.Communication;
using TheMazeAdventure.Core.Models;

namespace TheMazeAdventure.Core.Repositories
{
    /// <summary>
    /// Used for updating or getting the maze details.
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

        /// <summary>
        /// Gets the room by it's ID
        /// </summary>
        /// <param name="roomId">ID of room</param>
        /// <returns></returns>
        Task<RoomResponse> GetRoomByIdAsync(int roomId);
    }
}
