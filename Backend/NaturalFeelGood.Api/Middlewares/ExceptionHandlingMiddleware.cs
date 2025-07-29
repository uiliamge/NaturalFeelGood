using Application.Common.Interfaces;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace NaturalFeelGood.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IErrorMessageProvider _messages;

        public ExceptionHandlingMiddleware(RequestDelegate next,
                                           ILogger<ExceptionHandlingMiddleware> logger,
                                           IErrorMessageProvider messages)
        {
            _next = next;
            _logger = logger;
            _messages = messages;
        }

        public async Task Invoke(HttpContext context)
        {
            // Get language from Accept-Language header, default to "en"
            var language = context.Request.Headers["Accept-Language"].ToString()
                .Split(',')[0].Trim().ToLowerInvariant();
            if (string.IsNullOrEmpty(language)) language = "en";

            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error");

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest; // 400
                context.Response.ContentType = "application/json";

                var result = JsonSerializer.Serialize(new
                {
                    error = _messages.GetMessage("ValidationError", language),
                    details = ex.Errors.Select(e => new { field = e.PropertyName, message = e.ErrorMessage })
                });

                await context.Response.WriteAsync(result);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Not found");

                context.Response.StatusCode = (int)HttpStatusCode.NotFound; // 404
                context.Response.ContentType = "application/json";

                var result = JsonSerializer.Serialize(new
                {
                    error = _messages.GetMessage("NotFound", language),
                    details = ex.Message
                });

                await context.Response.WriteAsync(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; // 500
                context.Response.ContentType = "application/json";

                var result = JsonSerializer.Serialize(new
                {
                    error = _messages.GetMessage("UnexpectedError", language),
                    details = ex.Message
                });

                await context.Response.WriteAsync(result);
            }
        }
    }
}
