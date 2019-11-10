namespace Kibol_Alert.Responses.Wrappers.Factories
{
    public class ApiResponseFactory : IApiResponseFactory
    {
        public ApiSuccessResponse<T> Success<T>(T data) => new ApiSuccessResponse<T>(true, data);
        public ApiErrorResponse Error(string errorMessage) => new ApiErrorResponse(errorMessage);
    }
}
