
using NaturalFeelGood.Domain.Common;

namespace NaturalFeelGood.Application.Features.ElementTypes.Dtos
{
    public class UpdateElementTypeDto
    {
        public string Icon { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int Order { get; set; }
        public string Image { get; set; } = string.Empty;
        public Label Label { get; set; } = new Label();
    }
}
