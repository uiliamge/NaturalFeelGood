using Application.Common.Interfaces;

namespace Application.Common
{
    public class LanguageContext : ILanguageContext
    {
        public string Language { get; set; } = "en";
    }
}
