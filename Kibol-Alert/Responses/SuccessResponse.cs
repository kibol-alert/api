namespace Kibol_Alert.Responses
{
    public class SuccessResponse<T> : Response
    {
        public T Payload { get; set; }
        public SuccessResponse() : base(true)
        {
        }
        public SuccessResponse(T responseData)
            : base(true)
        {
            Payload = responseData;
        }
    }
}
