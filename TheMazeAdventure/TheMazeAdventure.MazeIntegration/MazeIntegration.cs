using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtlasCopco.Integration.Maze;

namespace TheMazeAdventure.MazeIntegration
{
    public class MazeIntegration: IMazeIntegration
    {

        public void BuildMaze(int size)
        {
            throw new NotImplementedException();
        }

        public int GetEntranceRoom()
        {
            throw new NotImplementedException();
        }

        public int? GetRoom(int roomId, char direction)
        {
            throw new NotImplementedException();
        }

        public string GetDescription(int roomId)
        {
            throw new NotImplementedException();
        }

        public bool HasTreasure(int roomId)
        {
            throw new NotImplementedException();
        }

        public bool CausesInjury(int roomId)
        {
            throw new NotImplementedException();
        }
    }
}
