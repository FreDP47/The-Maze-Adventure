using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMazeAdventure.Core.Communication;
using TheMazeAdventure.Core.Models;

namespace TheMazeAdventure.Core.Services
{
    /// <summary>
    /// Used for performing various operations on the maze.
    /// </summary>
    public interface IMazeService
    {
        /// <summary>
        /// Builds a new randomized maze with the given size. This is always called first.
        /// </summary>
        /// <param name="size">Width and height of maze dimensions.</param>
        /// <param name="dimension">object containing row and column value of entry room of maze</param>
        /// <param name="entryRoomId">out parameter where the id of the entry room is set</param>
        Task<(Room[,], int?)> BuildMazeLayoutAsync(int size, Dimension dimension);

        /// <summary>
        /// Randomly generates and returns the ID entrance room of the maze.
        /// </summary>
        /// <param name="size">Width and height of maze dimensions.</param>
        Task<Dimension> SetEntranceRoomAsync(int size);

        /// <summary>
        /// Saves the maze
        /// </summary>
        /// <param name="maze">maze</param>
        Task<MazeResponse> SaveMazeAsync(Maze maze);

        /// <summary>
        /// Fetches the room by its id
        /// </summary>
        /// <param name="roomId">ID fo the room</param>
        /// <returns></returns>
        Task<RoomResponse> GetRoomByIdAsync(int roomId);
    }
}
