using System;
using System.Linq;
using System.Threading.Tasks;
using TheMazeAdventure.Core.Models;
using TheMazeAdventure.Core.Repositories;

namespace TheMazeAdventure.Persistence
{
    public class MazeIntegrationRepository : IMazeIntegrationRepository
    {
        private Maze Maze { get; }

        public MazeIntegrationRepository(Maze maze)
        {
            Maze = maze;
        }

        public void UpdateRoomDescription(int roomId)
        {
            var room = GetRoomById(roomId);
            if (room == null) return;

            var initialRoomDesc = room.Description;
            var trapTriggerMessage = room.Type.BehaviourType?.TrapType?.TrapTriggerMessage;

            if (string.IsNullOrWhiteSpace(trapTriggerMessage)) return;
            var newRoom = new Room(room.Type, roomId, string.Concat(initialRoomDesc, trapTriggerMessage));
            var row = roomId / 10;
            var column = roomId % 10;
            Maze.Layout[row, column] = newRoom;
        }

        public Room GetRoomById(int roomId)
        {
            return Maze.Layout.Cast<Room>().FirstOrDefault(room => room.Id == roomId);
        }

        public Room[,] GetMazeLayout()
        {
            return Maze?.Layout;
        }

        public Room GetEntryRoom()
        {
            return Maze?.EntryPoint;
        }
    }
}
