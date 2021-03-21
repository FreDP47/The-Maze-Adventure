using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheMazeAdventure.Core.Models;
using TheMazeAdventure.Core.Repositories;
using TheMazeAdventure.Persistence;

namespace TheMazeAdventure.UnitTests.MazeTests
{
    [TestClass]
    public class MazeInMemoryRepositoryTests
    {
        private readonly IMazeRepository _mazeRepository;
        private readonly Maze _maze = new Maze(new[,]
        {
            {
                new Room(new RoomType("Test Room 1"), 1, 0 , 0), 
                new Room(new RoomType("Test Room 2"), 2, 0, 1)
            },
            {
                new Room(
                    new RoomType("Test Room 3")
                    {
                        Description = "Test Description",
                        BehaviourType = new Behaviour(false)
                            { TrapType = new Trap("Test trap", "Test trigger message", 40) }
                    }, 3, 1, 0),
                new Room(new RoomType("Test Room 4"), 4, 1, 1)
            }

        }, 0);

        public MazeInMemoryRepositoryTests()
        {
            _mazeRepository = new MazeInMemoryRepository();
            _mazeRepository.SaveMazeAsync(_maze);
        }

        [TestMethod]
        public void GetEntranceRoomId()
        {
            //arrange
            const int entryRoomId = 0;

            //act
            var entryRoomIdFromRepo = _mazeRepository.GetEntranceRoomId();

            //assert
            Assert.AreEqual(entryRoomId, entryRoomIdFromRepo);
        }

        [TestMethod]
        public async Task GetRoomByIdAsync_WhenIdIsValid()
        {
            //arrange
            const int id = 1;

            //act
            var result = await _mazeRepository.GetRoomByIdAsync(id);

            //assert
            Assert.IsNotNull(result.Room);
        }

        [TestMethod]
        public async Task GetRoomByIdAsync_WhenIdIsNotValid()
        {
            //arrange
            const int id = 0;

            //act
            var result = await _mazeRepository.GetRoomByIdAsync(id);

            //assert
            Assert.IsNull(result.Room);
        }
    }
}
