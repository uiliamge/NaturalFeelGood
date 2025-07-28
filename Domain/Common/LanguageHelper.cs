namespace NaturalFeelGood.Domain.Common
{
    public static class LanguageHelper
    {
        public static bool IsValidLanguage(string lang)
        {
            return lang == "en" || lang == "pt" || lang == "es";
        }
    }
}
