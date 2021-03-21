using System;
using System.Net.Http;
using System.Threading.Tasks;
using AtlasCopco.Integration.Maze;
using Newtonsoft.Json;
using TheMazeAdventure.MazeIntegration.Models;

namespace TheMazeAdventure.MazeIntegration
{
    public class MazeIntegration : IMazeIntegration
    {
        private HttpClient Client { get; }

        private static int _entryRoomId;
        private static int _size;
        private readonly Random _rnd;

        private const string ApiBaseAddress = "https://localhost:44351/";
        private const string BuildMazeRelativePath = "api/maze/{0}";
        private const string GetRoomByIdRelativePath = "api/maze/room/{0}";

        public MazeIntegration()
        {
            Client = new HttpClient { BaseAddress = new Uri(ApiBaseAddress) };
            _rnd = new Random();
        }

        public void BuildMaze(int size)
        {
            _size = size;
            var response = Client.PutAsync(string.Format(BuildMazeRelativePath, size), null).Result;
            if (!response.IsSuccessStatusCode) return;
            var mazeResource = DeserializeHttpResponse<MazeIntegrationMazeResource>(response).Result;
            _entryRoomId = mazeResource.EntryRoomId;
        }

        public int GetEntranceRoom()
        {
            return _entryRoomId;
        }

        public int? GetRoom(int roomId, char direction)
        {
            var room = GetRoomyId(roomId).Result;
            switch (direction)
            {
                case 'N':
                    return room.Row == 0 ? null : GetRoomyId(roomId - _size).Result?.Id;
                case 'S':
                    return room.Row == _size - 1 ? null : GetRoomyId(roomId + _size).Result?.Id;
                case 'E':
                    return room.Column == _size - 1 ? null : GetRoomyId(roomId + 1).Result?.Id;
                case 'W':
                    return room.Column == 0 ? null : GetRoomyId(roomId - 1).Result?.Id;
                default:
                    return null;
            }
        }

        public string GetDescription(int roomId)
        {
            var room = GetRoomyId(roomId).Result;
            return CausesInjury(roomId)
                ? string.Concat(room.Description, room.TrapType.TrapTriggerMessage)
                : room.Description;
        }

        public bool HasTreasure(int roomId)
        {
            var room = GetRoomyId(roomId).Result;
            return room.IsTreasureRoom;
        }

        public bool CausesInjury(int roomId)
        {
            var room = GetRoomyId(roomId).Result;
            if (room.TrapType == null)
                return false;
            var triggerBehaviour = _rnd.Next(1, 101);
            return triggerBehaviour <= room.TrapType.ChanceOfInjuryInPercentage;
        }

        private async Task<MazeIntegrationRoomResource> GetRoomyId(int id)
        {
            var response = await Client.GetAsync(string.Format(GetRoomByIdRelativePath, id));
            return !response.IsSuccessStatusCode
                ? null
                : await DeserializeHttpResponse<MazeIntegrationRoomResource>(response);
        }

        private static async Task<T> DeserializeHttpResponse<T>(HttpResponseMessage response)
        {
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
    }
}
