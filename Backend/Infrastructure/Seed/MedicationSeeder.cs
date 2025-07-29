using Amazon.DynamoDBv2.DataModel;
using NaturalFeelGood.Domain.Common;
using NaturalFeelGood.Domain.Entities;

namespace NaturalFeelGood.Infrastructure.Seed
{
    public static class MedicationSeeder
    {
        public static async Task SeedAsync(IDynamoDBContext context)
        {
            var items = new List<Medication>
            {
                new Medication
                {
                    Id = "omeprazole",
                    BrandName = new Label { En = "Prilosec", Pt = "Omeprazol", Es = "Omeprazol" },
                    GenericName = new Label { En = "Omeprazole", Pt = "Omeprazol", Es = "Omeprazol" },
                    Problems = new List<string> { "gastritis" }
                },
                new Medication
                {
                    Id = "loperamide",
                    BrandName = new Label { En = "Imodium", Pt = "Imosec", Es = "Imodium" },
                    GenericName = new Label { En = "Loperamide", Pt = "Loperamida", Es = "Loperamida" },
                    Problems = new List<string> { "irritable_bowel_syndrome" }
                },
                new Medication
                {
                    Id = "salbutamol",
                    BrandName = new Label { En = "Ventolin", Pt = "Aerolin", Es = "Salbutamol" },
                    GenericName = new Label { En = "Salbutamol", Pt = "Salbutamol", Es = "Salbutamol" },
                    Problems = new List<string> { "bronchitis" }
                },
                new Medication
                {
                    Id = "sumatriptan",
                    BrandName = new Label { En = "Imitrex", Pt = "Sumax", Es = "Sumatriptán" },
                    GenericName = new Label { En = "Sumatriptan", Pt = "Sumatriptana", Es = "Sumatriptán" },
                    Problems = new List<string> { "migraine" }
                },
                new Medication
                {
                    Id = "modafinil",
                    BrandName = new Label { En = "Provigil", Pt = "Modafinil", Es = "Modafinilo" },
                    GenericName = new Label { En = "Modafinil", Pt = "Modafinil", Es = "Modafinilo" },
                    Problems = new List<string> { "chronic_fatigue" }
                },
                new Medication
                {
                    Id = "amiodarone",
                    BrandName = new Label { En = "Cordarone", Pt = "Amiodarona", Es = "Amiodarona" },
                    GenericName = new Label { En = "Amiodarone", Pt = "Amiodarona", Es = "Amiodarona" },
                    Problems = new List<string> { "arrhythmia" }
                },
                new Medication
                {
                    Id = "cyclobenzaprine",
                    BrandName = new Label { En = "Flexeril", Pt = "Miosan", Es = "Ciclobenzaprina" },
                    GenericName = new Label { En = "Cyclobenzaprine", Pt = "Ciclobenzaprina", Es = "Ciclobenzaprina" },
                    Problems = new List<string> { "muscle_spasm" }
                },
                new Medication
                {
                    Id = "hydrocortisone",
                    BrandName = new Label { En = "Cortizone", Pt = "Androcortil", Es = "Hidrocortisona" },
                    GenericName = new Label { En = "Hydrocortisone", Pt = "Hidrocortisona", Es = "Hidrocortisona" },
                    Problems = new List<string> { "dermatitis" }
                },
                new Medication
                {
                    Id = "ibuprofen",
                    BrandName = new Label { En = "Advil", Pt = "Alivium", Es = "Ibuprofeno" },
                    GenericName = new Label { En = "Ibuprofen", Pt = "Ibuprofeno", Es = "Ibuprofeno" },
                    Problems = new List<string> { "dysmenorrhea" }
                }
            };

            foreach (var item in items)
            {
                var existing = await context.LoadAsync<Medication>(item.Id);
                if (existing == null)
                {
                    await context.SaveAsync(item);
                }
            }
        }
    }
}
