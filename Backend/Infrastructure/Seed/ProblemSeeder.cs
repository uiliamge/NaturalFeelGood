using Amazon.DynamoDBv2.DataModel;
using NaturalFeelGood.Domain.Common;
using NaturalFeelGood.Domain.Entities;

namespace NaturalFeelGood.Infrastructure.Seed
{
    public static class ProblemSeeder
    {
        public static async Task SeedAsync(IDynamoDBContext context)
        {
            var items = new List<HealthProblem>
            {
                new HealthProblem
                {
                    Id = "gastritis",
                    Label = new Label { En = "Gastritis", Pt = "Gastrite", Es = "Gastritis" },
                    SymptomsIds = new List<string> { "indigestion", "bloating" },
                },
                new HealthProblem
                {
                    Id = "irritable_bowel_syndrome",
                    Label = new Label { En = "Irritable Bowel Syndrome", Pt = "Síndrome do Intestino Irritável", Es = "Síndrome del Intestino Irritable" },
                    SymptomsIds = new List<string> { "bloating" },
                },
                new HealthProblem
                {
                    Id = "bronchitis",
                    Label = new Label { En = "Bronchitis", Pt = "Bronquite", Es = "Bronquitis" },
                    SymptomsIds = new List<string> { "cough", "shortness_of_breath" },
                },
                new HealthProblem
                {
                    Id = "migraine",
                    Label = new Label { En = "Migraine", Pt = "Enxaqueca", Es = "Migraña" },
                    SymptomsIds = new List<string> { "headache" },
                },
                new HealthProblem
                {
                    Id = "chronic_fatigue",
                    Label = new Label { En = "Chronic Fatigue", Pt = "Fadiga Crônica", Es = "Fatiga Crónica" },
                    SymptomsIds = new List<string> { "fatigue" },
                },
                new HealthProblem
                {
                    Id = "arrhythmia",
                    Label = new Label { En = "Arrhythmia", Pt = "Arritmia", Es = "Arritmia" },
                    SymptomsIds = new List<string> { "irregular_heartbeat" },
                },
                new HealthProblem
                {
                    Id = "muscle_spasm",
                    Label = new Label { En = "Muscle Spasm", Pt = "Espasmo Muscular", Es = "Espasmo Muscular" },
                    SymptomsIds = new List<string> { "muscle_cramp" },
                },
                new HealthProblem
                {
                    Id = "dermatitis",
                    Label = new Label { En = "Dermatitis", Pt = "Dermatite", Es = "Dermatitis" },
                    SymptomsIds = new List<string> { "skin_rash" },
                },
                new HealthProblem
                {
                    Id = "dysmenorrhea",
                    Label = new Label { En = "Dysmenorrhea", Pt = "Dismenorreia", Es = "Dismenorrea" },
                    SymptomsIds = new List<string> { "pelvic_pain" },
                }
            };

            foreach (var item in items)
            {
                var existing = await context.LoadAsync<HealthProblem>(item.Id);
                if (existing == null)
                {
                    await context.SaveAsync(item);
                }
            }
        }
    }
}
