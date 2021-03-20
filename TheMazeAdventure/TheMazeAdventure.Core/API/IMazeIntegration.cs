using System.Threading.Tasks;

namespace TheMazeAdventure.Core.API
{
    /// <summary>
    /// Used for integrating with external Treasure Adventure Emulators.
    /// </summary>
    public interface IMazeIntegration : IMazeBuilder
    {
        /// <summary>
        /// Gets the ID of the entrance room for the built maze.
        /// </summary>
        /// <returns>ID of the entrance room.</returns>
        Task<int> GetEntranceRoomAsync();

        /// <summary>
        /// Gets the room adjacent to the passed room, given a direction. NULL signals invalid room, i.e. edge of the maze.
        /// </summary>
        /// <param name="roomId">ID of the originating room.</param>
        /// <param name="direction">N, S, W or E.</param>
        /// <returns>ID of the room relative to the originating room.</returns>
        Task<int?> GetAdjacentRoomAsync(int roomId, char direction);

        /// <summary>
        /// Gets the computed textual description of the passed room.
        /// </summary>
        /// <param name="roomId">ID of a room.</param>
        /// <returns>Textual room description.</returns>
        Task<string> GetRoomDescriptionAsync(int roomId);

        /// <summary>
        /// Checks whether a room has a treasure.
        /// </summary>
        /// <param name="roomId">ID of a room.</param>
        /// <returns>True if the room has a treasure, or false if not.</returns>
        Task<bool> HasTreasureAsync(int roomId);

        /// <summary>
        /// Checks whether a room causes injury to the player.
        /// </summary>
        /// <param name="roomId">ID of a room.</param>
        /// <returns>True if the room causes injury (sinking, dehydration, etc), or false if not.</returns>
        Task<bool> CausesInjuryAsync(int roomId);
    }
}
