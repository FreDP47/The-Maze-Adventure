using System.Collections.Generic;
using System.Threading.Tasks;
using TheMazeAdventure.Core.Models;

namespace TheMazeAdventure.Core.Repositories
{
    /// <summary>
    /// Used for CRUD operations on different room types.
    /// </summary>
    public interface IRoomTypeRepository
    {
        /// <summary>
        /// Gets a list of different room types.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<RoomType>> GetAllRoomTypesAsync();
    }
}
