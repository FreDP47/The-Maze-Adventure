using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TheMazeAdventure.Core.Repositories;
using TheMazeAdventure.Core.Services;
using TheMazeAdventure.Services;
using Microsoft.Extensions.Logging;

namespace TheMazeAdventure.UnitTests.MazeIntegrationTests
{
    [TestClass]
    public class MazeServiceTests
    {
        private readonly IMazeService _mazeService;
        private readonly Mock<IMazeRepository> _mockRepo = new Mock<IMazeRepository>();
        private readonly Mock<ILogger<MazeService>> _mockLogger = new Mock<ILogger<MazeService>>();

        public MazeServiceTests()
        {
            _mazeService = new MazeService(_mockRepo.Object, _mockLogger.Object);
        }

        [TestMethod]
        public async Task BuildMazeLayout_WhenSizeIsNotValid()
        {
            //arrange
            const int size = 1;
            //act
            var mazeLayout = await _mazeService.BuildMazeLayoutAsync(size);

            //assert
            Assert.IsNull(mazeLayout);
        }

        [TestMethod]
        public async Task BuildMazeLayout_WhenSizeIsValid()
        {
            //arrange
            const int size = 3;
            //act
            var mazeLayout = await _mazeService.BuildMazeLayoutAsync(size);

            //assert
            Assert.AreEqual(size, mazeLayout.GetLength(0));
            Assert.AreEqual(size, mazeLayout.GetLength(1));
        }
    }
}
