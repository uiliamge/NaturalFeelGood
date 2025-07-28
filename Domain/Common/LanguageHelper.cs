namespace NaturalFeelGood.Domain.Common
{
    public static class LanguageHelper
    {
        public static string GetLabel(Label label, string language)
        {
            if (label == null) return string.Empty;
            return language switch
            {
                "pt" => label.Pt ?? label.En ?? string.Empty,
                "es" => label.Es ?? label.En ?? string.Empty,
                _ => label.En ?? string.Empty
            };
        }

        public static bool IsValidLanguage(string lang)
        {
            return lang == "en" || lang == "pt" || lang == "es";
        }
    }
}
