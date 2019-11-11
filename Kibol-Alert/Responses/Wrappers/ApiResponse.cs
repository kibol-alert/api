namespace Kibol_Alert.Responses.Wrappers
{
    public abstract class ApiResponse
    {
        public bool Success { get; set; }

        public ApiResponse(bool success)
        {
            Success = success;
        }
    }
}
