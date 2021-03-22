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
                var enumerableListOfRoomTypes = await _roomTypeRepository.GetAllRoomTypesAsync();
                var listOfRoomTypes = enumerableListOfRoomTypes.ToList();

                //build the layout with rooms types other than treasure room
                //creating a list of all room types excluding the treasure room type to fill the initial layout
                var listOfRoomTypesWithoutTreasureRoom =
                    listOfRoomTypes.Where(rType =>
                        (rType.BehaviourType != null && !rType.BehaviourType.IsTreasureThere) ||
                        rType.BehaviourType == null).ToArray();
                CreateInitialLayout(listOfRoomTypesWithoutTreasureRoom, size, ref layoutArray);

                //use the row and column of the entry room passed as parameters to find the entry room cell from the 
                //layout and then replace it with an empty room and use the id of the initial room for the new 
                //room as well
                SetupStartRoom(listOfRoomTypes.FirstOrDefault(rType => rType.BehaviourType == null), dimension,
                    ref layoutArray);

                //set the treasure room
                var entryRoomId = layoutArray[dimension.Row, dimension.Column].Id;
                var treasureRoomType = listOfRoomTypes.FirstOrDefault(rType =>
                    rType.BehaviourType != null && rType.BehaviourType.IsTreasureThere);
                SetupTreasureRoom(treasureRoomType, size, entryRoomId, ref layoutArray);

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
                //List of values b/w 0 and the size(exclusive) of the array
                var possibleValues = Enumerable.Range(0, size).ToList();
                //Set of 2 values - 0 and the size of the array
                var possibleEdgeValues = new List<int>() {0, size - 1};

                var row = GenerateRandomNumberFromListOfNumbers(possibleValues);
                //if generated row is at the edge of the maze then choose any column
                //if generated row is any value b/w 0 and size of array of the maze
                //then choose the column from one of the edges
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

        private void CreateInitialLayout(IReadOnlyList<RoomType> roomTypes, int size, ref Room[,] layoutArray)
        {
            var id = 1;
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    var roomType = roomTypes[_rnd.Next(roomTypes.Count)];
                    layoutArray[i, j] = new Room(roomType, id, i, j);
                    id++;
                }
            }
        }

        private void SetupStartRoom(RoomType emptyRoomType, Dimension dimension, ref Room[,] layoutArray)
        {
            var entryRoomId = layoutArray[dimension.Row, dimension.Column].Id;
            layoutArray[dimension.Row, dimension.Column] = new Room(emptyRoomType, entryRoomId,
                dimension.Row, dimension.Column);
        }

        private void SetupTreasureRoom(RoomType treasureRoomType, int size, int entryRoomId, ref Room[,] layoutArray)
        {
            //list of possible room id values excluding the entry room id
            var possibleTreasureRoomIdValues = Enumerable.Range(1, size * size).ToList();
            possibleTreasureRoomIdValues.Remove(entryRoomId);
            //finding the cell in the layout whose id matches with the randomly generated id from
            //the possible treasure room id values and replacing it with the treasure room using
            //the id of the initial room present there
            var isTreasureRoomSet = false;
            var randomlyChooseTreasureRoomId = GenerateRandomNumberFromListOfNumbers(possibleTreasureRoomIdValues);
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    if (layoutArray[i, j].Id != randomlyChooseTreasureRoomId) continue;
                    layoutArray[i, j] = new Room(treasureRoomType, randomlyChooseTreasureRoomId, i, j);
                    isTreasureRoomSet = true;
                    break;
                }
                if (isTreasureRoomSet)
                    break;
            }
        }

        private int GenerateRandomNumberFromListOfNumbers(IEnumerable<int> list)
        {
            var arrayOfNumbers = list.ToArray();
            return arrayOfNumbers[_rnd.Next(arrayOfNumbers.Length)];
        }
    }
}
