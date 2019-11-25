namespace Kibol_Alert.Responses.Wrappers
{
    public class ApiSuccessResponse<T> : ApiResponse
    {
        public T Data { get; set; }

        public ApiSuccessResponse(bool success, T responseData) 
            : base(success)
        {
            Data = responseData;
        }
    }
}
