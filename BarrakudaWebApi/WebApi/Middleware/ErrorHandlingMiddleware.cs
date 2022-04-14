using Application.Exceptions;
using System.Net;

namespace WebApi.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger _logger;
        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception exception)
            {
                var response = context.Response;

                switch (exception)
                {
                    case BadRequestException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case NotFoundException:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case ForbidException:
                        response.StatusCode = (int)HttpStatusCode.Forbidden;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        _logger.LogError(exception, exception.Message);
                        await context.Response.WriteAsync(exception.ToString());
                        return;
                }

                _logger.LogError(exception, exception.Message);
                await context.Response.WriteAsync(exception.Message);
            }
        }
    }
}
