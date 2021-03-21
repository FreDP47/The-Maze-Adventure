using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TheMazeAdventure.Core.Communication;
using TheMazeAdventure.Core.Models;
using TheMazeAdventure.Core.Repositories;
using TheMazeAdventure.Core.Services;

namespace TheMazeAdventure.Services
{
    public class MazeService: IMazeService
    {
        private readonly IMazeRepository _mazeRepository;
        private readonly ILogger<MazeService> _logger;
        public MazeService(IMazeRepository mazeIntegrationRepository, ILogger<MazeService> logger)
        {
            _mazeRepository = mazeIntegrationRepository;
            _logger = logger;
        }

        public Task<Room[,]> BuildMazeLayoutAsync(int size)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Some error occurred while building the maze {Time}", DateTime.Now);
                return null;
            }
        }

        public int? SetEntranceRoom(int size)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Some error occurred while setting the entrance room at {Time}", DateTime.Now);
                return null;
            }
        }

        public async Task<MazeResponse> SaveMaze(Maze maze)
        {
            try
            {
                await _mazeRepository.SaveMazeAsync(maze);
                return new MazeResponse(maze);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Some error occurred at {Time}", DateTime.Now);
                return new MazeResponse($"Some Error occurred while saving the maze: {ex.Message}");
            }
        }
    }
}
