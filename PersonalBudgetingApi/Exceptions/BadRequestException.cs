namespace PersonalBudgetingApi.Exceptions
{
    public class BadRequestException(string message) : ApiException(message, ErrorCode.BadRequest, 400)
    {
    }
}