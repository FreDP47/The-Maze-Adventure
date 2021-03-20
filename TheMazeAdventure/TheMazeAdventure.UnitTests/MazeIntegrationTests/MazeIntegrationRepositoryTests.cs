using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TheMazeAdventure.Core.Models;
using TheMazeAdventure.Core.Repositories;
using TheMazeAdventure.Persistence;

namespace TheMazeAdventure.UnitTests.MazeIntegrationTests
{
    [TestClass]
    public class MazeIntegrationRepositoryTests
    {
        private readonly IMazeIntegrationRepository _mazeIntegrationRepository;
        private readonly Maze _maze = new Maze(new[,]
        {
            {new Room(new RoomType("Test Room 1"), 00, "Test Description"), new Room(new RoomType("Test Room 2"), 01, "Test Description")},
            {
                new Room(
                    new RoomType("Test Room 3")
                    {
                        Description = "Test Description",
                        BehaviourType = new Behaviour(false)
                            {TrapType = new Trap("Test trap", "Test trigger message", 40)}
                    }, 10, "Test Description"),
                new Room(new RoomType("Test Room 4"), 11, "Test Description")
            }

        }, new Room(new RoomType("Test Room"), 00, "Test Description"));

        public MazeIntegrationRepositoryTests()
        {
            _mazeIntegrationRepository = new MazeIntegrationRepository(_maze);
        }

        [TestMethod]
        public void GetRoomById_WhenExists()
        {
            //arrange
            const int roomId = 01;
            
            //act
            var room = _mazeIntegrationRepository.GetRoomById(roomId);

            //assert
            Assert.AreEqual(room.Id, roomId);
        }

        [TestMethod]
        public void GetRoomById_WhenDoesNotExist()
        {
            //arrange
            const int roomId = 50;

            //act
            var room = _mazeIntegrationRepository.GetRoomById(roomId);

            //assert
            Assert.IsNull(room);
        }

        [TestMethod]
        public void UpdateRoomDescription_WhenExists()
        {
            //arrange
            const int roomId = 10;
            var room = _mazeIntegrationRepository.GetRoomById(roomId);
            var initialDesc = room.Description;
            var finalDesc = string.Concat(initialDesc, room.Type.BehaviourType.TrapType.TrapTriggerMessage);

            //act
            _mazeIntegrationRepository.UpdateRoomDescription(roomId);

            //assert
            Assert.AreEqual(finalDesc, _mazeIntegrationRepository.GetRoomById(roomId).Description);
        }

        [TestMethod]
        public void UpdateRoomDescription_WhenDoesNotExist()
        {
            //arrange
            const int roomId = 03;
            var room = _mazeIntegrationRepository.GetRoomById(roomId);

            //act
            _mazeIntegrationRepository.UpdateRoomDescription(roomId);

            //assert
            Assert.IsNull(room);
        }
    }
}
