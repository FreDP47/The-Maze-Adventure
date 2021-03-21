using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
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
        //private readonly ILogger<MazeService> _logger;
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
                        layoutArray[i, j] = new Room(roomType, id, roomType.Description, i, j);
                        id++;
                    }
                }

                //Setting the entrance room
                var emptyRoomType = listOfRoomTypes.FirstOrDefault(rType => rType.BehaviourType == null);
                var entryRoomId = layoutArray[dimension.Row, dimension.Column].Id;
                layoutArray[dimension.Row, dimension.Column] = new Room(emptyRoomType, entryRoomId,
                    emptyRoomType.Description, dimension.Row, dimension.Column);

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
                        layoutArray[i, j] = new Room(treasureRoomType, randomlyChooseTreasureRoomId,
                            treasureRoomType.Description, i, j);
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
                //_logger.LogCritical(ex, "Some error occurred while building the maze {Time}", DateTime.Now);
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
                //_logger.LogCritical(ex, "Some error occurred while setting the entrance room at {Time}", DateTime.Now);
                return null;
            }
        }

        public async Task<MazeResponse> SaveMazeAsync(Maze maze)
        {
            try
            {
                await _mazeRepository.SaveMazeAsync(maze);
                return new MazeResponse(maze);
            }
            catch (Exception ex)
            {
                //_logger.LogCritical(ex, "Some error occurred at {Time}", DateTime.Now);
                return new MazeResponse($"Some Error occurred while saving the maze: {ex.Message}");
            }
        }

        private int GenerateRandomNumberFromListOfNumbers(IEnumerable<int> list)
        {
            var arrayOfNumbers = list.ToArray();
            return arrayOfNumbers[_rnd.Next(arrayOfNumbers.Length)];
        }
    }
}
