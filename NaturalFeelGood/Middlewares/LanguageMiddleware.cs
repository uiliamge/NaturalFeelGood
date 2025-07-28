using Application.Common.Interfaces;

namespace NaturalFeelGood.Api.Middlewares
{
    public class LanguageMiddleware
    {
        private readonly RequestDelegate _next;

        public LanguageMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILanguageContext languageContext)
        {
            var lang = context.Request.Headers["Accept-Language"].FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(lang))
                languageContext.Language = lang.Split(',')[0].Trim().ToLower(); // ex: "pt-BR" → "pt"

            await _next(context);
        }
    }

}
