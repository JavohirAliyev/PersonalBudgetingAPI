using System.Net;
using System.Text.Json;

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

                if (ex is ArgumentException)
                {
                    statusCode = (int)HttpStatusCode.BadRequest;
                    message = "Invalid argument provided.";
                }
                if (ex is UnauthorizedAccessException)
                {
                    statusCode = (int)HttpStatusCode.Unauthorized;
                    message = "Access denied.";
                }
                if (ex is KeyNotFoundException)
                {
                    statusCode = (int)HttpStatusCode.NotFound;
                    message = "Resource not found.";
                }
                if (ex is InvalidOperationException)
                {
                    statusCode = (int)HttpStatusCode.Conflict;
                    message = "Operation cannot be performed in the current state.";
                }

                var response = new
                {
                    statusCode,
                    message,
                    detail = ex.Message
                };

                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
