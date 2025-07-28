
namespace NaturalFeelGood.Domain.Common
{
    public class Label
    {
        public string En { get; set; } = string.Empty;
        public string Pt { get; set; } = string.Empty;
        public string Es { get; set; } = string.Empty;

        public string Get(string language)
        {
            return language switch
            {
                "pt" => Pt ?? En ?? string.Empty,
                "es" => Es ?? En ?? string.Empty,
                _ => En ?? string.Empty
            };
        }

    }
}
