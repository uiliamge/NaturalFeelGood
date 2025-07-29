using Application.Common.Interfaces;
using System.Text.Json;

namespace NaturalFeelGood.Api.Implementations
{
    public class ErrorMessageProvider : IErrorMessageProvider
    {
        private readonly Dictionary<string, Dictionary<string, string>> _messages;

        public ErrorMessageProvider(IWebHostEnvironment env)
        {
            var path = Path.Combine(env.ContentRootPath, "Resources", "error-messages.json");
            var json = File.ReadAllText(path);
            _messages = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(json)!;
        }

        public string GetMessage(string key, string language)
        {
            if (_messages.TryGetValue(key, out var translations))
            {
                return translations.TryGetValue(language, out var message)
                    ? message
                    : translations.GetValueOrDefault("en", key);
            }

            return key;
        }
    }
}
