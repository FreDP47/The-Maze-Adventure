using System;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using TheMazeAdventure.Core.Models;
using TheMazeAdventure.Core.Resources;
using TheMazeAdventure.Core.Services;

namespace TheMazeAdventure.API.Controllers
{
    [RoutePrefix("api/maze")]
    public class MazeController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IMazeService _mazeIntegrationService;
        public MazeController(IMazeService mazeIntegrationService, IMapper mapper)
        {
            _mazeIntegrationService = mazeIntegrationService;
            _mapper = mapper;
        }

        [Route("{size:int}")]
        [HttpPut]
        public async Task<IHttpActionResult> BuildSquareMazeAsync(int size)
        {
            if(size <=1)
                return BadRequest("Provided size is invalid. The value should be greater or equal to 2");

            var entryRoomDimension = await _mazeIntegrationService.SetEntranceRoomAsync(size);
            if(entryRoomDimension == null)
                return BadRequest("Some Error occurred while creating the maze.");

            var (mazeLayout, entryRoomId) = await _mazeIntegrationService.BuildMazeLayoutAsync(size, entryRoomDimension);
            if (mazeLayout == null || entryRoomId == null)
                return BadRequest("Some Error occurred while creating the maze.");

            var result = await _mazeIntegrationService.SaveMazeAsync(
                new Maze(mazeLayout, Convert.ToInt32(entryRoomId)));
            if(!result.Success)
                return BadRequest(result.Message);
            var mazeResource = _mapper.Map<Maze, MazeResource>(result.Maze);
            return Ok(mazeResource);
        }

        [Route("room/{id:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetRoomByIdAsync(int id)
        {
            var result = await _mazeIntegrationService.GetRoomByIdAsync(id);

            if(!result.Success)
                return NotFound();
            if (result.Room == null)
                return NotFound();

            var roomResource = _mapper.Map<Room, RoomResource>(result.Room);
            return Ok(roomResource);
        }
    }
}
