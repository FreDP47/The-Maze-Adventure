using TheMazeAdventure.Core.Models;

namespace TheMazeAdventure.Core.Communication
{
    public class MazeResponse: BaseResponse
    {
        public Maze Maze { get; }

        private MazeResponse(bool success, string message, Maze maze) : base(success, message)
        {
            Maze = maze;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="maze">Saved maze.</param>
        /// <returns>Response.</returns>
        public MazeResponse(Maze maze) : this(true, string.Empty, maze) { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public MazeResponse(string message) : this(false, message, null) { }
    }
}
