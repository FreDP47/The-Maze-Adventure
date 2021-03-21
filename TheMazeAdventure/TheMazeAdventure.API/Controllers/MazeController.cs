using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using TheMazeAdventure.Core.Models;
using TheMazeAdventure.Core.Resources;
using TheMazeAdventure.Core.Services;

namespace TheMazeAdventure.API.Controllers
{
    public class MazeController : ApiController
    {
        private readonly IMazeService _mazeIntegrationService;
        private readonly IMapper _mapper;
        public MazeController(IMazeService mazeIntegrationService, IMapper mapper)
        {
            _mazeIntegrationService = mazeIntegrationService;
            _mapper = mapper;
        }

        public async Task<IHttpActionResult> BuildSquareMazeAsync(int size)
        {
            var mazeLayout = await _mazeIntegrationService.BuildMazeLayoutAsync(size);
            var entryRoomId = _mazeIntegrationService.SetEntranceRoom(size);
            if (mazeLayout == null || entryRoomId == null)
                return BadRequest("Some Error occurred while creating the maze.");

            var result = await _mazeIntegrationService.SaveMaze(
                new Maze(mazeLayout, Convert.ToInt64(entryRoomId)));
            if(!result.Success)
                return BadRequest(result.Message);
            var mazeResource = _mapper.Map<Maze, MazeResource>(result.Maze);
            return Ok(mazeResource);
        }
    }
}
