using System;
using System.Threading.Tasks;
using TheMazeAdventure.Core.Repositories;
using TheMazeAdventure.Core.Services;

namespace TheMazeAdventure.Services
{
    public class MazeIntegrationService: IMazeIntegrationService
    {
        private readonly IMazeIntegrationRepository _mazeIntegrationRepository;
        public MazeIntegrationService(IMazeIntegrationRepository mazeIntegrationRepository)
        {
            _mazeIntegrationRepository = mazeIntegrationRepository;
        }

        public void BuildMaze(int size)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetEntranceRoom()
        {
            throw new NotImplementedException();
        }

        public Task<int?> GetAdjacentRoom(int roomId, char direction)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoomDescription(int roomId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasTreasure(int roomId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CausesInjury(int roomId)
        {
            throw new NotImplementedException();
        }
    }
}
