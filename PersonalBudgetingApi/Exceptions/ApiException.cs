namespace PersonalBudgetingApi.Exceptions
{
    public class ApiException(string message, ErrorCode code, int statusCode) : Exception(message)
    {
        public int StatusCode { get; } = statusCode;
        public ErrorCode Code { get; } = code;
    }

    public enum ErrorCode
    {
        BadRequest,
        Conflict,
        NotFound,
        Unauthorized,
        Forbidden,
        ValidationFailed,
        InternalError
    }
}