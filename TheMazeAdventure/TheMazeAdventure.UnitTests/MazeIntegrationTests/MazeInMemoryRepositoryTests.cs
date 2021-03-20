using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TheMazeAdventure.Core.Models;
using TheMazeAdventure.Core.Repositories;
using TheMazeAdventure.Persistence;

namespace TheMazeAdventure.UnitTests.MazeIntegrationTests
{
    [TestClass]
    public class MazeInMemoryRepositoryTests
    {
        private readonly IMazeRepository _mazeRepository;
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

        }, "00");

        public MazeInMemoryRepositoryTests()
        {
            _mazeRepository = new MazeInMemoryRepository();
            _mazeRepository.SaveMaze(_maze);
        }

        [TestMethod]
        public void GetEntranceRoomId()
        {
            //arrange
            const string entryRoomId = "00";

            //act
            var entryRoomIdFromRepo = _mazeRepository.GetEntranceRoomId();

            //assert
            Assert.AreEqual(entryRoomId, entryRoomIdFromRepo);
        }
    }
}
