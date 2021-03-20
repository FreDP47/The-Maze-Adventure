using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TheMazeAdventure.Core.Models;
using TheMazeAdventure.Core.Repositories;
using TheMazeAdventure.Core.Services;
using TheMazeAdventure.Services;

namespace TheMazeAdventure.UnitTests.MazeIntegrationTests
{
    [TestClass]
    public class MazeServiceTests
    {
        private readonly IMazeService _mazeService;
        private readonly Mock<IMazeRepository> _mockRepo = new Mock<IMazeRepository>();

        public MazeServiceTests()
        {
            _mazeService = new MazeService(_mockRepo.Object);
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
