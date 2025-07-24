using Amazon.DynamoDBv2.DataModel;
using NaturalFeelGood.Domain.Common;
using NaturalFeelGood.Domain.Entities;

namespace NaturalFeelGood.Infrastructure.Seed
{
    public static class ContraindicationTypeSeeder
    {
        public static async Task SeedAsync(IDynamoDBContext context)
        {
            var items = new List<ContraindicationType>
                {
                    new ContraindicationType
                    {
                        Id = "pregnancy",
                        Label = new Label { En = "Not for use during pregnancy", Pt = "Contraindicado na gravidez", Es = "Contraindicado durante el embarazo" },
                        Icon = "🚫🤰"
                    },
                    new ContraindicationType
                    {
                        Id = "hypertension",
                        Label = new Label { En = "Avoid in hypertension", Pt = "Evitar em casos de hipertensão", Es = "Evitar en hipertensión" },
                        Icon = "⚠️💓"
                    },
                    new ContraindicationType
                    {
                        Id = "children",
                        Label = new Label { En = "Not suitable for children", Pt = "Não indicado para crianças", Es = "No apto para niños" },
                        Icon = "🚫🧒"
                    },
                    new ContraindicationType
                    {
                        Id = "diabetes",
                        Label = new Label { En = "Use with caution in diabetes", Pt = "Usar com cautela em casos de diabetes", Es = "Usar con precaución en diabetes" },
                        Icon = "⚠️🍬"                        
                    },
                    new ContraindicationType
                    {
                        Id = "allergy",
                        Label = new Label { En = "May cause allergic reaction", Pt = "Pode causar reação alérgica", Es = "Puede causar reacción alérgica" },
                        Icon = "⚠️🌿"
                    }
                };

            foreach (var item in items)
            {
                var existing = await context.LoadAsync<ContraindicationType>(item.Id);
                if (existing == null)
                {
                    await context.SaveAsync(item);
                }
            }
        }
    }
}
