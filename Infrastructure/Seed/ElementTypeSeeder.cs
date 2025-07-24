
using Amazon.DynamoDBv2.DataModel;
using NaturalFeelGood.Domain.Common;
using NaturalFeelGood.Domain.Entities;

namespace NaturalFeelGood.Infrastructure.Seed
{
    public static class ElementTypeSeeder
    {
        public static async Task SeedAsync(IDynamoDBContext context)
        {
            var items = new List<ElementType>
                {
                    new ElementType
                    {
                        Id = "herb",
                        Label = new Label { En = "Herb", Pt = "Planta", Es = "Hierba" },
                        Icon = "🌿",
                        Color = "#4CAF50",
                        Order = 1,
                        Image = "herb.jpg"
                    },
                    new ElementType
                    {
                        Id = "tea",
                        Label = new Label { En = "Tea", Pt = "Chá", Es = "Té" },
                        Icon = "🍵",
                        Color = "#81C784",
                        Order = 2,
                        Image = "tea.jpg"
                    },
                    new ElementType
                    {
                        Id = "mushroom",
                        Label = new Label { En = "Mushroom", Pt = "Cogumelo", Es = "Hongo" },
                        Icon = "🍄",
                        Color = "#A1887F",
                        Order = 3,
                        Image = "mushroom.jpg"
                    },
                    new ElementType
                    {
                        Id = "mineral",
                        Label = new Label { En = "Mineral", Pt = "Mineral", Es = "Mineral" },
                        Icon = "⛏️",
                        Color = "#B0BEC5",
                        Order = 4,
                        Image = "mineral.jpg"
                    },
                    new ElementType
                    {
                        Id = "vitamin",
                        Label = new Label { En = "Vitamin", Pt = "Vitamina", Es = "Vitamina" },
                        Icon = "💊",
                        Color = "#FFB74D",
                        Order = 5,
                        Image = "vitamin.jpg"
                    }
                };

            foreach (var item in items)
            {
                var existing = await context.LoadAsync<ElementType>(item.Id);
                if (existing == null)
                {
                    await context.SaveAsync(item);
                }
            }
        }
    }
}
