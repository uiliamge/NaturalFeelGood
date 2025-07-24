using Amazon.DynamoDBv2.DataModel;
using NaturalFeelGood.Domain.Common;
using NaturalFeelGood.Domain.Entities;

namespace NaturalFeelGood.Infrastructure.Seed
{
    public static class OrganSeeder
    {
        public static async Task SeedAsync(IDynamoDBContext context)
        {
            var items = new List<Organ>
            {
                new Organ
                {
                    Id = "stomach",
                    Label = new Label { En = "Stomach", Pt = "Estômago", Es = "Estómago" },
                    BodySystemCategoryId = "digestive",
                    Image = "stomach.jpg"
                },
                new Organ
                {
                    Id = "lungs",
                    Label = new Label { En = "Lungs", Pt = "Pulmões", Es = "Pulmones" },
                    BodySystemCategoryId = "respiratory",
                    Image = "lungs.jpg"
                },
                new Organ
                {
                    Id = "brain",
                    Label = new Label { En = "Brain", Pt = "Cérebro", Es = "Cerebro" },
                    BodySystemCategoryId = "nervous",
                    Image = "brain.jpg"
                },
                new Organ
                {
                    Id = "heart",
                    Label = new Label { En = "Heart", Pt = "Coração", Es = "Corazón" },
                    BodySystemCategoryId = "circulatory",
                    Image = "heart.jpg"
                },
                new Organ
                {
                    Id = "muscles",
                    Label = new Label { En = "Muscles", Pt = "Músculos", Es = "Músculos" },
                    BodySystemCategoryId = "muscular",
                    Image = "muscles.jpg"
                },
                new Organ
                {
                    Id = "bones",
                    Label = new Label { En = "Bones", Pt = "Ossos", Es = "Huesos" },
                    BodySystemCategoryId = "skeletal",
                    Image = "bones.jpg"
                },
                new Organ
                {
                    Id = "kidneys",
                    Label = new Label { En = "Kidneys", Pt = "Rins", Es = "Riñones" },
                    BodySystemCategoryId = "renal",
                    Image = "kidneys.jpg"
                },
                new Organ
                {
                    Id = "skin",
                    Label = new Label { En = "Skin", Pt = "Pele", Es = "Piel" },
                    BodySystemCategoryId = "integumentary",
                    Image = "skin.jpg"
                },
                new Organ
                {
                    Id = "intestines",
                    Label = new Label { En = "Intestines", Pt = "Intestinos", Es = "Intestinos" },
                    BodySystemCategoryId = "digestive",
                    Image = "intestines.jpg"
                },
                new Organ
                {
                    Id = "uterus",
                    Label = new Label { En = "Uterus", Pt = "Útero", Es = "Útero" },
                    BodySystemCategoryId = "reproductive",
                    Image = "uterus.jpg"
                }
            };

            foreach (var item in items)
            {
                var existing = await context.LoadAsync<Organ>(item.Id);
                if (existing == null)
                {
                    await context.SaveAsync(item);
                }
            }
        }
    }
}
