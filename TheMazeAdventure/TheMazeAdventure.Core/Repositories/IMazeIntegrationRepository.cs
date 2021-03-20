using System.Threading.Tasks;
using TheMazeAdventure.Core.Models;

namespace TheMazeAdventure.Core.Repositories
{
    /// <summary>
    /// Used for updating or getting the maze details which is stored in memory.
    /// </summary>
    public interface IMazeIntegrationRepository: IGetMazeDetailsRepository
    {
        /// <summary>
        /// Updates the room description if it's behaviour has been triggered.
        /// </summary>
        /// <param name="roomId">id of the room</param>
        void UpdateRoomDescription(int roomId);

        /// <summary>
        /// Gets the room by it's id.
        /// </summary>
        /// <param name="roomId">id of the room</param>
        /// <returns>room</returns>
        Room GetRoomById(int roomId);
    }
}
