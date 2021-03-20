namespace TheMazeAdventure.Core.API
{
    /// <summary>
    /// Used for building standard square mazes.
    /// Inherit this when creating IMazeBuilder.
    /// </summary>
    public interface IStandardMazeBuilder
    {
        /// <summary>
        /// Builds a new randomized square maze with the given size. This is always called first.
        /// </summary>
        /// <param name="size">Width and height of maze dimensions.</param>
        void BuildSquareMazeAsync(int size);
    }
}
