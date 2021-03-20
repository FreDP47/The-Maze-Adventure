using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMazeAdventure.Core.Services
{
    /// <summary>
    /// Used for performing various operations on the maze.
    /// </summary>
    public interface IMazeIntegrationService
    {
        /// <summary>
        /// Builds a new randomized maze with the given size. This is always called first.
        /// </summary>
        /// <param name="size">Width and height of maze dimensions.</param>
        void BuildMaze(int size);

        /// <summary>
        /// Gets the ID of the entrance room for the built maze.
        /// </summary>
        /// <returns>ID of the entrance room.</returns>
        Task<int> GetEntranceRoom();

        /// <summary>
        /// Gets the room adjacent to the passed room, given a direction. NULL signals invalid room, i.e. edge of the maze.
        /// </summary>
        /// <param name="roomId">ID of the originating room.</param>
        /// <param name="direction">N, S, W or E.</param>
        /// <returns>ID of the room relative to the originating room.</returns>
        Task<int?> GetAdjacentRoom(int roomId, char direction);

        /// <summary>
        /// Gets the computed textual description of the passed room.
        /// </summary>
        /// <param name="roomId">ID of a room.</param>
        /// <returns>Textual room description.</returns>
        Task<string> GetRoomDescription(int roomId);

        /// <summary>
        /// Checks whether a room has a treasure.
        /// </summary>
        /// <param name="roomId">ID of a room.</param>
        /// <returns>True if the room has a treasure, or false if not.</returns>
        Task<bool> HasTreasure(int roomId);

        /// <summary>
        /// Checks whether a room causes injury to the player.
        /// </summary>
        /// <param name="roomId">ID of a room.</param>
        /// <returns>True if the room causes injury (sinking, dehydration, etc), or false if not.</returns>
        Task<bool> CausesInjury(int roomId);
    }
}
