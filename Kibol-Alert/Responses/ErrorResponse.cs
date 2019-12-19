namespace Kibol_Alert.Responses
{
    public class ErrorResponse : Response
    {
        public string ErrorMessage { get; set; }
        public ErrorResponse() : base(false)
        {
        }
        public ErrorResponse(string message) : base(false)
        {
            ErrorMessage = message;
        }
    }
}
