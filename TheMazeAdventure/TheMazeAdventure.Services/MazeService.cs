using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheMazeAdventure.Core.Communication;
using TheMazeAdventure.Core.Models;
using TheMazeAdventure.Core.Repositories;
using TheMazeAdventure.Core.Services;

namespace TheMazeAdventure.Services
{
    public class MazeService : IMazeService
    {
        private readonly IMazeRepository _mazeRepository;
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly Random _rnd;
        public MazeService(IMazeRepository mazeIntegrationRepository, IRoomTypeRepository roomTypeRepository)
        {
            _mazeRepository = mazeIntegrationRepository;
            _roomTypeRepository = roomTypeRepository;
            _rnd = new Random();
        }

        public async Task<(Room[,], int?)> BuildMazeLayoutAsync(int size, Dimension dimension)
        {
            try
            {
                if (size <= 1) return (null, null);
                var layoutArray = new Room[size, size];
                var rnd = new Random();
                var enumerableListOfRoomTypes = await _roomTypeRepository.GetAllRoomTypesAsync();
                var listOfRoomTypes = enumerableListOfRoomTypes.ToList();
                var listOfRoomTypesWithoutTreasureRoom =
                    listOfRoomTypes.Where(rType =>
                        (rType.BehaviourType != null && !rType.BehaviourType.IsTreasureThere) ||
                        rType.BehaviourType == null).ToArray();

                //Build the layout with rooms types other than treasure room
                var id = 1;
                for (var i = 0; i < size; i++)
                {
                    for (var j = 0; j < size; j++)
                    {
                        var roomType =
                            listOfRoomTypesWithoutTreasureRoom[rnd.Next(listOfRoomTypesWithoutTreasureRoom.Length)];
                        layoutArray[i, j] = new Room(roomType, id, i, j);
                        id++;
                    }
                }

                //Setting the entrance room
                var emptyRoomType = listOfRoomTypes.FirstOrDefault(rType => rType.BehaviourType == null);
                var entryRoomId = layoutArray[dimension.Row, dimension.Column].Id;
                layoutArray[dimension.Row, dimension.Column] = new Room(emptyRoomType, entryRoomId,
                     dimension.Row, dimension.Column);

                //Setting the treasure room
                var treasureRoomType = listOfRoomTypes.FirstOrDefault(rType =>
                    rType.BehaviourType != null && rType.BehaviourType.IsTreasureThere);
                var possibleValues = Enumerable.Range(1, size * size);

                var isTreasureRoomSet = false;
                var randomlyChooseTreasureRoomId = GenerateRandomNumberFromListOfNumbers(possibleValues);
                for (var i = 0; i < size; i++)
                {
                    for (var j = 0; j < size; j++)
                    {
                        if (layoutArray[i, j].Id != randomlyChooseTreasureRoomId) continue;
                        layoutArray[i, j] = new Room(treasureRoomType, randomlyChooseTreasureRoomId, i, j);
                        isTreasureRoomSet = true;
                        break;
                    }
                    if(isTreasureRoomSet)
                        break;
                }

                return (layoutArray, entryRoomId);
            }
            catch (Exception)
            {
                return (null, null);
            }
        }

        public Task<Dimension> SetEntranceRoomAsync(int size)
        {
            try
            {
                if (size <= 1) return null;
                var possibleValues = Enumerable.Range(0, size).ToList();
                var possibleEdgeValues = new List<int>() {0, size - 1};

                var row = GenerateRandomNumberFromListOfNumbers(possibleValues);
                var column = possibleEdgeValues.Contains(row)
                    ? GenerateRandomNumberFromListOfNumbers(possibleValues)
                    : GenerateRandomNumberFromListOfNumbers(possibleEdgeValues);

                return Task.Run(() => new Dimension(row, column));

            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<MazeResponse> SaveMazeAsync(Maze maze)
        {
            try
            {
                return await _mazeRepository.SaveMazeAsync(maze);
            }
            catch (Exception ex)
            {
                return new MazeResponse($"Some Error occurred while saving the maze: {ex.Message}");
            }
        }

        public async Task<RoomResponse> GetRoomByIdAsync(int roomId)
        {
            try
            {
                return await _mazeRepository.GetRoomByIdAsync(roomId);
            }
            catch (Exception ex)
            {
                return new RoomResponse($"Some Error occurred while saving the maze: {ex.Message}");
            }
        }

        private int GenerateRandomNumberFromListOfNumbers(IEnumerable<int> list)
        {
            var arrayOfNumbers = list.ToArray();
            return arrayOfNumbers[_rnd.Next(arrayOfNumbers.Length)];
        }
    }
}
