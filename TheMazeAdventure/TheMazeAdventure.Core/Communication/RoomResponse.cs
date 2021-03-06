using TheMazeAdventure.Core.Models;

namespace TheMazeAdventure.Core.Communication
{
    public class RoomResponse: BaseResponse
    {
        public Room Room { get; }

        private RoomResponse(bool success, string message, Room room) : base(success, message)
        {
            Room = room;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="room">room</param>
        /// <returns>Response.</returns>
        public RoomResponse(Room room) : this(true, string.Empty, room) { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public RoomResponse(string message) : this(false, message, null) { }
    }
}
