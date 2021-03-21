using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheMazeAdventure.Core.Models;
using TheMazeAdventure.Core.Repositories;
using TheMazeAdventure.Persistence;

namespace TheMazeAdventure.UnitTests.MazeIntegrationTests
{
    [TestClass]
    public class MazeInMemoryRepositoryTests
    {
        private readonly IMazeRepository _mazeRepository;

        public MazeInMemoryRepositoryTests()
        {
            _mazeRepository = new MazeInMemoryRepository();
            
        }

        [TestMethod]
        public async Task GetEntranceRoomId()
        {
            //arrange
            const int entryRoomId = 0;
            var maze = new Maze(new[,]
            {
                {new Room(new RoomType("Test Room 1"), 0, "Test Description", 0 , 0), new Room(new RoomType("Test Room 2"), 1, "Test Description", 0, 1)},
                {
                    new Room(
                        new RoomType("Test Room 3")
                        {
                            Description = "Test Description",
                            BehaviourType = new Behaviour(false)
                                {TrapType = new Trap("Test trap", "Test trigger message", 40)}
                        }, 2, "Test Description", 1, 0),
                    new Room(new RoomType("Test Room 4"), 2, "Test Description", 1, 1)
                }

            }, 0);
            await _mazeRepository.SaveMazeAsync(maze);

            //act
            var entryRoomIdFromRepo = _mazeRepository.GetEntranceRoomId();

            //assert
            Assert.AreEqual(entryRoomId, entryRoomIdFromRepo);
        }
    }
}
