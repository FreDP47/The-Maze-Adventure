using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TheMazeAdventure.Core.API;
using TheMazeAdventure.Core.Services;

namespace TheMazeAdventure.API.Controllers
{
    public class MazeIntegrationController : ApiController, IMazeIntegration
    {
        private readonly IMazeIntegrationService _mazeIntegrationService;
        public MazeIntegrationController(IMazeIntegrationService mazeIntegrationService)
        {
            _mazeIntegrationService = mazeIntegrationService;
        }

        public async void BuildSquareMazeAsync(int size)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetEntranceRoomAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int?> GetAdjacentRoomAsync(int roomId, char direction)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetRoomDescriptionAsync(int roomId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> HasTreasureAsync(int roomId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CausesInjuryAsync(int roomId)
        {
            throw new NotImplementedException();
        }
    }
}
