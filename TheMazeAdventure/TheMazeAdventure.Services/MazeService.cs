using System;
using System.Threading.Tasks;
using TheMazeAdventure.Core.Models;
using TheMazeAdventure.Core.Repositories;
using TheMazeAdventure.Core.Services;

namespace TheMazeAdventure.Services
{
    public class MazeService: IMazeService
    {
        private readonly IMazeRepository _mazeRepository;
        public MazeService(IMazeRepository mazeIntegrationRepository)
        {
            _mazeRepository = mazeIntegrationRepository;
        }

        public Task<Room[,]> BuildMazeLayoutAsync(int size)
        {
            throw new NotImplementedException();
        }

        public string SetEntranceRoom(int size)
        {
            throw new NotImplementedException();
        }

        public void SaveMaze(Maze maze)
        {
            _mazeRepository.SaveMaze(maze);
        }

        public string GetEntranceRoomId()
        {
            return _mazeRepository.GetEntranceRoomId();
        }

        public Task<Room[,]> BuildMazeLayout(int size)
        {
            throw new NotImplementedException();
        }
    }
}
