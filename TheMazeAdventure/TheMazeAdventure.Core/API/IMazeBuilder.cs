using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMazeAdventure.Core.API
{
    /// <summary>
    /// Used for building different types of mazes.
    /// </summary>
    public interface IMazeBuilder
    {
        /// <summary>
        /// Builds a new randomized square maze with the given size. This is always called first.
        /// </summary>
        /// <param name="size">Width and height of maze dimensions.</param>
        void BuildSquareMazeAsync(int size);
    }
}
