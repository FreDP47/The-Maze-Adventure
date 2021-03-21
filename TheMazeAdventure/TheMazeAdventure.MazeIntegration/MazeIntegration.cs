using System;
using System.Net.Http;
using System.Threading.Tasks;
using AtlasCopco.Integration.Maze;
using TheMazeAdventure.Core.Resources;
using TheMazeAdventure.Utility;

namespace TheMazeAdventure.MazeIntegration
{
    public class MazeIntegration : IMazeIntegration
    {
        private HttpClient Client { get; }

        private static int _entryRoomId;
        private static int _size;
        private readonly Random _rnd;

        public MazeIntegration()
        {
            Client = new HttpClient { BaseAddress = new Uri(Constants.ApiBaseAddress) };
            _rnd = new Random();
        }

        public async void BuildMazeAsync(int size)
        {
            _size = size;
            var response = await Client.PutAsync(string.Format(Constants.BuildMazeRelativePath, size), new StringContent(null));
            if (!response.IsSuccessStatusCode) return;
            var mazeResource = await Methods.DeserializeHttpResponse<MazeResource>(response);
            _entryRoomId = mazeResource.EntryRoomId;
        }

        public int GetEntranceRoom()
        {
            return _entryRoomId;
        }

        public int? GetRoom(int roomId, char direction)
        {
            switch (direction)
            {
                case 'N':
                    return GetRoom(roomId - _size).Result?.Id;
                case 'S':
                    return GetRoom(roomId + _size).Result?.Id;
                case 'E':
                    return GetRoom(roomId + 1).Result?.Id;
                case 'W':
                    return GetRoom(roomId - 1).Result?.Id;
                default:
                    return null;
            }
        }

        public string GetDescription(int roomId)
        {
            var room = GetRoom(roomId).Result;
            return CausesInjury(roomId)
                ? string.Concat(room.Description, room.TrapType.TrapTriggerMessage)
                : room.Description;
        }

        public bool HasTreasure(int roomId)
        {
            var room = GetRoom(roomId).Result;
            return room.isTreasureRoom;
        }

        public bool CausesInjury(int roomId)
        {
            var room = GetRoom(roomId).Result;
            if (room.TrapType == null)
                return false;
            var generateInjury = _rnd.Next(1, 101);
            return generateInjury <= room.TrapType.ChanceOfInjuryInPercentage;
        }

        private async Task<RoomResource> GetRoom(int id)
        {
            var response = await Client.GetAsync(string.Format(Constants.GetRoomByIdRelativePath, id));
            return !response.IsSuccessStatusCode
                ? null
                : await Methods.DeserializeHttpResponse<RoomResource>(response);
        }
    }
}
