namespace Assignment.API.Middlewares
{
    public class TokenValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TokenValidationMiddleware> _logger;

        public TokenValidationMiddleware(RequestDelegate next, ILogger<TokenValidationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token))
            {
                _logger.LogWarning("Authorization token is missing.");
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized - Missing token");
                return;
            }

            try
            {
                // If the token is invalid, return Unauthorized
                if (token == "user1")
                {
                    _logger.LogWarning("Invalid authorization token.");
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Unauthorized - Invalid token");
                    return;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error validating authorization token: {ex.Message}");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("Internal Server Error");
                return;
            }

            await _next(context);
        }
    }
}
