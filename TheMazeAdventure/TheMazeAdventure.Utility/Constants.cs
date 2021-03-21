using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMazeAdventure.Utility
{
    public static class Constants
    {
        public const string ApiBaseAddress = "https://localhost:44351/";
        public const string BuildMazeRelativePath = "api/maze/{0}";
        public const string GetRoomByIdRelativePath = "api/maze/room/{0}";
    }
}
