using System.Net;
using System.Text.Json;
using PersonalBudgetingApi.Exceptions;

namespace PersonalBudgetingApi.Middleware
{
    public class ExceptionHandlingMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                var statusCode = (int)HttpStatusCode.InternalServerError;
                var message = "An unexpected error occurred.";
                string errorCode = ErrorCode.InternalError.ToString();

                if (ex is ArgumentException)
                {
                    statusCode = (int)HttpStatusCode.BadRequest;
                    message = "Invalid argument provided.";
                    errorCode = ErrorCode.BadRequest.ToString();
                }
                if (ex is ApiException apiEx)
                {
                    statusCode = apiEx.StatusCode;
                    message = apiEx.Message;
                    errorCode = apiEx.Code.ToString();
                }

                var response = new
                {
                    statusCode,
                    message,
                    detail = ex.Message,
                    ErrorCode = errorCode,
                };

                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
