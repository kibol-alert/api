namespace Kibol_Alert.Responses.Wrappers.Factories
{
    public interface IApiResponseFactory
    {
        ApiErrorResponse Error(string errorMessage);
        ApiSuccessResponse<T> Success<T>(T data);
    }
}