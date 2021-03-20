﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        Task<Room[,]> BuildMazeLayoutAsync(int size);

        /// <summary>
        /// Randomly generates and returns the ID entrance room of the maze.
        /// </summary>
        /// <param name="size">Width and height of maze dimensions.</param>
        string SetEntranceRoom(int size);

        /// <summary>
        /// Saves the maze
        /// </summary>
        /// <param name="maze">maze</param>
        void SaveMaze(Maze maze);

        /// <summary>
        /// Gets the ID of the entrance room for the built maze.
        /// </summary>
        /// <returns>ID of the entrance room.</returns>
        string GetEntranceRoomId();
    }
}