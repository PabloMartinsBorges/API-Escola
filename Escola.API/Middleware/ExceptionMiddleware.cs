using Escola.API.Erros;

namespace Escola.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                var response = _env.IsDevelopment()
                    ? new ApiException(httpContext.Response.StatusCode.ToString(), ex.Message, ex.StackTrace?.ToString())
                    : new ApiException(httpContext.Response.StatusCode.ToString(), ex.Message, null);

                //options to serialize the response object to JSON with camelCase property naming
                var options = new System.Text.Json.JsonSerializerOptions { PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase };
                //serialize the response object to JSON
                var json = System.Text.Json.JsonSerializer.Serialize(response, options);

                await httpContext.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
