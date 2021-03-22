namespace TheMazeAdventure.Core.Communication
{
    public abstract class BaseResponse
    {
        public bool Success { get; }
        public string Message { get; }

        protected BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
