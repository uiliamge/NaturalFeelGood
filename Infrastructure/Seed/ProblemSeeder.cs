using Amazon.DynamoDBv2.DataModel;
using NaturalFeelGood.Domain.Common;
using NaturalFeelGood.Domain.Entities;

namespace NaturalFeelGood.Infrastructure.Seed
{
    public static class ProblemSeeder
    {
        public static async Task SeedAsync(IDynamoDBContext context)
        {
            var items = new List<Problem>
            {
                new Problem
                {
                    Id = "gastritis",
                    Label = new Label { En = "Gastritis", Pt = "Gastrite", Es = "Gastritis" },
                    Symptoms = new List<string> { "indigestion", "bloating" },
                },
                new Problem
                {
                    Id = "irritable_bowel_syndrome",
                    Label = new Label { En = "Irritable Bowel Syndrome", Pt = "Síndrome do Intestino Irritável", Es = "Síndrome del Intestino Irritable" },
                    Symptoms = new List<string> { "bloating" },
                },
                new Problem
                {
                    Id = "bronchitis",
                    Label = new Label { En = "Bronchitis", Pt = "Bronquite", Es = "Bronquitis" },
                    Symptoms = new List<string> { "cough", "shortness_of_breath" },
                },
                new Problem
                {
                    Id = "migraine",
                    Label = new Label { En = "Migraine", Pt = "Enxaqueca", Es = "Migraña" },
                    Symptoms = new List<string> { "headache" },
                },
                new Problem
                {
                    Id = "chronic_fatigue",
                    Label = new Label { En = "Chronic Fatigue", Pt = "Fadiga Crônica", Es = "Fatiga Crónica" },
                    Symptoms = new List<string> { "fatigue" },
                },
                new Problem
                {
                    Id = "arrhythmia",
                    Label = new Label { En = "Arrhythmia", Pt = "Arritmia", Es = "Arritmia" },
                    Symptoms = new List<string> { "irregular_heartbeat" },
                },
                new Problem
                {
                    Id = "muscle_spasm",
                    Label = new Label { En = "Muscle Spasm", Pt = "Espasmo Muscular", Es = "Espasmo Muscular" },
                    Symptoms = new List<string> { "muscle_cramp" },
                },
                new Problem
                {
                    Id = "dermatitis",
                    Label = new Label { En = "Dermatitis", Pt = "Dermatite", Es = "Dermatitis" },
                    Symptoms = new List<string> { "skin_rash" },
                },
                new Problem
                {
                    Id = "dysmenorrhea",
                    Label = new Label { En = "Dysmenorrhea", Pt = "Dismenorreia", Es = "Dismenorrea" },
                    Symptoms = new List<string> { "pelvic_pain" },
                }
            };

            foreach (var item in items)
            {
                var existing = await context.LoadAsync<Problem>(item.Id);
                if (existing == null)
                {
                    await context.SaveAsync(item);
                }
            }
        }
    }
}
