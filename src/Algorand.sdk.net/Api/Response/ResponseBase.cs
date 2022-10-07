namespace Algorand.SDK.Dotnet.Api.Response
{
    public class ResponseBase<T>
    {
        internal ResponseBase(T response)
        {
            Response = response;
        }

        internal ResponseBase(T response, string errorMessage)
        {
            Response = response;
            ErrorMessage = errorMessage;
        }

        public T Response { get; set; }
        public string ErrorMessage { get; set; }
        public bool Succeed
            => string.IsNullOrWhiteSpace(ErrorMessage) && !(Response == null);

        public static ResponseBase<T> Success(T response)
            => new ResponseBase<T>(response);

        public static ResponseBase<T> Error(T response, string errorMessage)
            => new ResponseBase<T>(response, errorMessage);
    }
}