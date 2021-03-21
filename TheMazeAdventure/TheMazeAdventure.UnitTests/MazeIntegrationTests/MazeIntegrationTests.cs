using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //_mazeIntegration.BuildMazeAsync(3);
            //var entryRoomID = _mazeIntegration.GetEntranceRoom();
            //_mazeIntegration.
        }
    }
}
