using AtlasCopco.Integration.Maze;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheMazeAdventure.MazeIntegration;

namespace TheMazeAdventure.UnitTests.MazeIntegrationTests
{
    [TestClass]
    public class MazeIntegrationTests
    {
        private readonly IMazeIntegration _mazeIntegration;
        public MazeIntegrationTests()
        {
            _mazeIntegration = new MazeIntegration.MazeIntegration();
        }
        [TestMethod]
        public void MazeIntegrationTest()
        {
            _mazeIntegration.BuildMaze(3);
            for (var i = 1; i < 10; i++)
            {
                _mazeIntegration.CausesInjury(i);
            }
            //_mazeIntegration.HasTreasure(1);
            //var entryRoomID = _mazeIntegration.GetEntranceRoom();
            //_mazeIntegration.
        }
    }
}
