using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TheMazeAdventure.Core.Repositories;
using TheMazeAdventure.Core.Services;
using TheMazeAdventure.Services;
using Microsoft.Extensions.Logging;
using TheMazeAdventure.Core.Models;

namespace TheMazeAdventure.UnitTests.MazeIntegrationTests
{
    [TestClass]
    public class MazeServiceTests
    {
        private readonly IMazeService _mazeService;
        private readonly Mock<IMazeRepository> _mockMazeRepo = new Mock<IMazeRepository>();
        private readonly Mock<IRoomTypeRepository> _mockRoomTyeRepo = new Mock<IRoomTypeRepository>();
        private readonly Mock<ILogger<MazeService>> _mockLogger = new Mock<ILogger<MazeService>>();

        public MazeServiceTests()
        {
            _mazeService = new MazeService(_mockMazeRepo.Object, _mockRoomTyeRepo.Object);
        }

        [TestMethod]
        public async Task BuildMazeLayout_WhenNoExceptionOccurs()
        {
            //arrange
            const int size = 3;
            var dimension = new Dimension(2,0);
            var roomTypes = new List<RoomType>()
            {
                new RoomType("Empty Room")
                {
                    Description = "You see an empty room",
                    BehaviourType = null
                },
                new RoomType("Treasure Room")
                {
                    Description = "You see the treasure and your eyes light up",
                    BehaviourType = new Behaviour(true)
                },
                new RoomType("Marsh")
                {
                    Description = "You are looking at a heap of leaves and feel slightly elated.",
                    BehaviourType = new Behaviour(false)
                    {
                        TrapType =
                            new Trap
                            (
                                "marshes", " But you immediately begin to sink", 30
                            )
                    }
                },
                new RoomType("Desert")
                {
                    Description = "You are looking at a desert with heaps of sands and feel thirsty.",
                    BehaviourType = new Behaviour(false)
                    {
                        TrapType =
                            new Trap
                            (
                                "marshes", " But you immediately begin to dehydrate", 20
                            )
                    }
                }
            };
            _mockRoomTyeRepo.Setup(rep => rep.GetAllRoomTypesAsync()).ReturnsAsync(roomTypes);

            //act
            var (mazeLayout, entryRoomId) = await _mazeService.BuildMazeLayoutAsync(size, dimension);

            //assert
            Assert.IsNotNull(entryRoomId);
            Assert.AreEqual(size, mazeLayout.GetLength(0));
            Assert.AreEqual(size, mazeLayout.GetLength(1));
        }

        [TestMethod]
        public async Task BuildMazeLayout_WhenExceptionOccurs()
        {
            //arrange
            const int size = 3;
            var dimension = new Dimension(2, 0);
            _mockRoomTyeRepo.Setup(rep => rep.GetAllRoomTypesAsync()).Throws(new Exception());

            //act
            var (mazeLayout, entryRoomId) = await _mazeService.BuildMazeLayoutAsync(size, dimension);

            //assert
            Assert.IsNull(entryRoomId);
            Assert.IsNull(mazeLayout);
        }

        [TestMethod]
        public async Task SetEntranceRoom_WhenNoExceptionOccurs()
        {
            //arrange
            const int size = 3;

            //act
            var entryRoomDimension = await _mazeService.SetEntranceRoomAsync(size);

            //assert
            Assert.IsNotNull(entryRoomDimension);
        }
    }
}
