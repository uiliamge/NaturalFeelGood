
using Amazon.DynamoDBv2.DataModel;
using NaturalFeelGood.Domain.Common;
using NaturalFeelGood.Domain.Entities;

namespace NaturalFeelGood.Infrastructure.Seed
{
    public static class BodySystemCategorySeeder
    {
        public static async Task SeedAsync(IDynamoDBContext context)
        {
            var items = new List<BodySystem>
                {
                    new BodySystem
                    {
                        Id = "digestive",
                        Label = new Label { En = "Digestive", Pt = "Digestivo", Es = "Digestivo" },
                        Icon = "🍽️",
                        Color = "#FF9800",
                        Order = 1,
                        Image = "digestive.jpg"
                    },
                    new BodySystem
                    {
                        Id = "respiratory",
                        Label = new Label { En = "Respiratory", Pt = "Respiratório", Es = "Respiratorio" },
                        Icon = "🌬️",
                        Color = "#03A9F4",
                        Order = 2,
                        Image = "respiratory.jpg"
                    },
                    new BodySystem
                    {
                        Id = "nervous",
                        Label = new Label { En = "Nervous", Pt = "Nervoso", Es = "Nervioso" },
                        Icon = "🧠",
                        Color = "#9C27B0",
                        Order = 3,
                        Image = "nervous.jpg"
                    },
                    new BodySystem
                    {
                        Id = "immune",
                        Label = new Label { En = "Immune", Pt = "Imunológico", Es = "Inmunológico" },
                        Icon = "🛡️",
                        Color = "#4CAF50",
                        Order = 4,
                        Image = "immune.jpg"
                    },
                    new BodySystem
                    {
                        Id = "circulatory",
                        Label = new Label { En = "Circulatory", Pt = "Circulatório", Es = "Circulatorio" },
                        Icon = "❤️",
                        Color = "#E53935",
                        Order = 5,
                        Image = "circulatory.jpg"
                    },
                    new BodySystem
                    {
                        Id = "muscular",
                        Label = new Label { En = "Muscular", Pt = "Muscular", Es = "Muscular" },
                        Icon = "💪",
                        Color = "#795548",
                        Order = 6,
                        Image = "muscular.jpg"
                    },
                    new BodySystem
                    {
                        Id = "skeletal",
                        Label = new Label { En = "Skeletal", Pt = "Esquelético", Es = "Esquelético" },
                        Icon = "🦴",
                        Color = "#607D8B",
                        Order = 7,
                        Image = "skeletal.jpg"
                    },
                    new BodySystem
                    {
                        Id = "renal",
                        Label = new Label { En = "Renal", Pt = "Renal", Es = "Renal" },
                        Icon = "🧪",
                        Color = "#00BCD4",
                        Order = 8,
                        Image = "renal.jpg"
                    },
                    new BodySystem
                    {
                        Id = "reproductive",
                        Label = new Label { En = "Reproductive", Pt = "Reprodutivo", Es = "Reproductivo" },
                        Icon = "⚧️",
                        Color = "#F06292",
                        Order = 9,
                        Image = "reproductive.jpg"
                    },
                    new BodySystem
                    {
                        Id = "integumentary",
                        Label = new Label { En = "Integumentary", Pt = "Tegumentar", Es = "Tegumentario" },
                        Icon = "🧴",
                        Color = "#AED581",
                        Order = 10,
                        Image = "integumentary.jpg"
                    }
                };

            foreach (var item in items)
            {
                var existing = await context.LoadAsync<BodySystem>(item.Id);
                if (existing == null)
                {
                    await context.SaveAsync(item);
                }
            }
        }
    }
}
