using TheMazeAdventure.Core.Models;

namespace TheMazeAdventure.Core.Repositories
{
    /// <summary>
    /// Used for getting maze stored in memory by using singleton design pattern.
    /// Inherit this when creating IMazeRepository.
    /// </summary>
    public interface IGetMazeDetailsRepository
    {
        /// <summary>
        /// Gets layout of maze stored in memory by using singleton design pattern.
        /// </summary>
        /// <returns>maze</returns>
        Room[,] GetMazeLayout();

        /// <summary>
        /// Gets entry room of maze stored in memory
        /// </summary>
        /// <returns></returns>
        Room GetEntryRoom();
    }
}
