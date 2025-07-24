using Amazon.DynamoDBv2.DataModel;
using NaturalFeelGood.Domain.Common;
using NaturalFeelGood.Domain.Entities;

namespace NaturalFeelGood.Infrastructure.Seed
{
    public static class SymptomSeeder
    {
        public static async Task SeedAsync(IDynamoDBContext context)
        {
            var items = new List<Symptom>
            {
                new Symptom
                {
                    Id = "indigestion",
                    Label = new Label { En = "Indigestion", Pt = "Indigest�o", Es = "Indigesti�n" },
                    OrganId = "stomach"
                },
                new Symptom
                {
                    Id = "bloating",
                    Label = new Label { En = "Bloating", Pt = "Incha�o", Es = "Hinchaz�n" },
                    OrganId = "intestines"
                },
                new Symptom
                {
                    Id = "cough",
                    Label = new Label { En = "Cough", Pt = "Tosse", Es = "Tos" },
                    OrganId = "lungs"
                },
                new Symptom
                {
                    Id = "shortness_of_breath",
                    Label = new Label { En = "Shortness of breath", Pt = "Falta de ar", Es = "Falta de aire" },
                    OrganId = "lungs"
                },
                new Symptom
                {
                    Id = "headache",
                    Label = new Label { En = "Headache", Pt = "Dor de cabe�a", Es = "Dolor de cabeza" },
                    OrganId = "brain"
                },
                new Symptom
                {
                    Id = "fatigue",
                    Label = new Label { En = "Fatigue", Pt = "Fadiga", Es = "Fatiga" },
                    OrganId = "muscles"
                },
                new Symptom
                {
                    Id = "irregular_heartbeat",
                    Label = new Label { En = "Irregular heartbeat", Pt = "Batimento card�aco irregular", Es = "Latido card�aco irregular" },
                    OrganId = "heart"
                },
                new Symptom
                {
                    Id = "muscle_cramp",
                    Label = new Label { En = "Muscle cramp", Pt = "C�ibra muscular", Es = "Calambre muscular" },
                    OrganId = "muscles"
                },
                new Symptom
                {
                    Id = "skin_rash",
                    Label = new Label { En = "Skin rash", Pt = "Erup��o cut�nea", Es = "Erupci�n cut�nea" },
                    OrganId = "skin"
                },
                new Symptom
                {
                    Id = "pelvic_pain",
                    Label = new Label { En = "Pelvic pain", Pt = "Dor p�lvica", Es = "Dolor p�lvico" },
                    OrganId = "uterus"
                }
            };

            foreach (var item in items)
            {
                var existing = await context.LoadAsync<Symptom>(item.Id);
                if (existing == null)
                {
                    await context.SaveAsync(item);
                }
            }
        }
    }
}
