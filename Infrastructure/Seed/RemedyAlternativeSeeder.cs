using Amazon.DynamoDBv2.DataModel;
using NaturalFeelGood.Domain.Common;
using NaturalFeelGood.Domain.Entities;

namespace NaturalFeelGood.Infrastructure.Seed
{
    public static class RemedyAlternativeSeeder
    {
        public static async Task SeedAsync(IDynamoDBContext context)
        {
            var items = new List<NaturalElement>
            {
                new NaturalElement
                {
                    Id = "chamomile_tea",
                    Type = "tea",
                    Label = new Label { En = "Chamomile Tea", Pt = "Chá de Camomila", Es = "Té de Manzanilla" },
                    Image = "chamomile.jpg",
                    Description = "",
                    RelatedMedications = new List<string> { "omeprazole", "sumatriptan" },
                    RelatedProblems = new List<string> { "gastritis", "migraine" },
                    RelatedSymptoms = new List<string>(),
                    RelatedContraindicationTypes = new List<string>(),
                },
                new NaturalElement
                {
                    Id = "peppermint_tea",
                    Type = "tea",
                    Label = new Label { En = "Peppermint Tea", Pt = "Chá de Hortelã", Es = "Té de Menta" },
                    Image = "peppermint.jpg",
                    Description = "",
                    RelatedMedications = new List<string> { "loperamide" },
                    RelatedProblems = new List<string> { "irritable_bowel_syndrome" },
                    RelatedSymptoms = new List<string>(),
                    RelatedContraindicationTypes = new List<string>(),
                },
                new NaturalElement
                {
                    Id = "eucalyptus_inhalation",
                    Type = "herb",
                    Label = new Label { En = "Eucalyptus Inhalation", Pt = "Inalação de Eucalipto", Es = "Inhalación de Eucalipto" },
                    Image = "eucalyptus.jpg",
                    Description = "",
                    RelatedMedications = new List<string> { "salbutamol" },
                    RelatedProblems = new List<string> { "bronchitis" },
                    RelatedSymptoms = new List<string>(),
                    RelatedContraindicationTypes = new List<string>(),
                },
                new NaturalElement
                {
                    Id = "lavender_oil",
                    Type = "herb",
                    Label = new Label { En = "Lavender Oil", Pt = "Óleo de Lavanda", Es = "Aceite de Lavanda" },
                    Image = "lavender.jpg",
                    Description = "",
                    RelatedMedications = new List<string> { "modafinil", "sumatriptan" },
                    RelatedProblems = new List<string> { "chronic_fatigue", "migraine" },
                    RelatedSymptoms = new List<string>(),
                    RelatedContraindicationTypes = new List<string>(),
                },
                new NaturalElement
                {
                    Id = "arnica_extract",
                    Type = "herb",
                    Label = new Label { En = "Arnica Extract", Pt = "Extrato de Arnica", Es = "Extracto de Árnica" },
                    Image = "arnica.jpg",
                    Description = "",
                    RelatedMedications = new List<string> { "cyclobenzaprine" },
                    RelatedProblems = new List<string> { "muscle_spasm" },
                    RelatedSymptoms = new List<string>(),
                    RelatedContraindicationTypes = new List<string>(),
                },
                new NaturalElement
                {
                    Id = "aloe_vera_gel",
                    Type = "herb",
                    Label = new Label { En = "Aloe Vera Gel", Pt = "Gel de Aloe Vera", Es = "Gel de Aloe Vera" },
                    Image = "aloe_vera.jpg",
                    Description = "",
                    RelatedMedications = new List<string> { "hydrocortisone" },
                    RelatedProblems = new List<string> { "dermatitis" },
                    RelatedSymptoms = new List<string>(),
                    RelatedContraindicationTypes = new List<string>(),
                },
                new NaturalElement
                {
                    Id = "cinnamon_tea",
                    Type = "tea",
                    Label = new Label { En = "Cinnamon Tea", Pt = "Chá de Canela", Es = "Té de Canela" },
                    Image = "cinnamon.jpg",
                    Description = "",
                    RelatedMedications = new List<string> { "ibuprofen" },
                    RelatedProblems = new List<string> { "dysmenorrhea" },
                    RelatedSymptoms = new List<string>(),
                    RelatedContraindicationTypes = new List<string>(),
                }
            };

            foreach (var item in items)
            {
                var existing = await context.LoadAsync<NaturalElement>(item.Id);
                if (existing == null)
                {
                    await context.SaveAsync(item);
                }
            }
        }
    }
}
