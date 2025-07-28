namespace PersonalBudgetingApi.Exceptions
{
    public class NotFoundException(string message) : ApiException(message, ErrorCode.NotFound, 404)
    {
    }
}