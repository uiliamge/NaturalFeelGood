// Application/Features/Medications/Queries/GetMedicationByNameHandler.cs

using Application.Features.BodySystem.Dtos;
using Application.Features.Medications.Dtos;
using Application.Features.Organ;
using Application.Features.Problem.Dtos;
using Application.Features.RemedyAlternative.Dtos;
using Application.Features.Symptom.Dtos;
using MediatR;
using NaturalFeelGood.Application.Features.Medications.Queries;
using NaturalFeelGood.Domain.Interfaces;
using System.Globalization;

namespace NaturalFeelGood.Application.Features.Medications.Handlers
{
    public class GetMedicationByNameHandler : IRequestHandler<GetMedicationByNameQuery, MedicationDetailDto?>
    {
        private readonly IMedicationRepository _medicationRepository;
        private readonly IProblemRepository _problemRepository;
        private readonly IOrganRepository _organRepository;
        private readonly IBodySystemCategoryRepository _categoryRepository;
        private readonly ISymptomRepository _symptomRepository;
        private readonly IRemedyAlternativeRepository _remedyRepository;

        public GetMedicationByNameHandler(
            IMedicationRepository medicationRepository,
            IProblemRepository problemRepository,
            IOrganRepository organRepository,
            IBodySystemCategoryRepository categoryRepository,
            ISymptomRepository symptomRepository,
            IRemedyAlternativeRepository remedyRepository)
        {
            _medicationRepository = medicationRepository;
            _problemRepository = problemRepository;
            _organRepository = organRepository;
            _categoryRepository = categoryRepository;
            _symptomRepository = symptomRepository;
            _remedyRepository = remedyRepository;
        }

        public async Task<MedicationDetailDto?> Handle(GetMedicationByNameQuery request, CancellationToken cancellationToken)
        {
            var medication = await _medicationRepository.GetByBrandOrGenericNameAsync(request.Name);
            if (medication is null) return null;

            // Use current UI culture or fallback to "en"
            var language = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            if (string.IsNullOrWhiteSpace(language) || !IsValidLanguage(language))
                language = "en";

            var problems = new List<ProblemDto>();
            foreach (var problemId in medication.Problems)
            {
                var problem = await _problemRepository.GetByIdAsync(problemId);
                if (problem == null) continue;

                var organ = await _organRepository.GetByIdAsync(problem.OrganId);
                var category = organ != null ? await _categoryRepository.GetByIdAsync(organ.BodySystemId) : null;
                var symptoms = await _symptomRepository.GetByIdsAsync(problem.SymptomsIds);

                problems.Add(new ProblemDto
                {
                    Id = problem.Id,
                    Label = GetLabel(problem.Label, language),
                    Organ = organ == null ? null : new OrganDto
                    {
                        Id = organ.Id,
                        Label = GetLabel(organ.Label, language),
                        Category = category == null ? null : new BodySystemDto
                        {
                            Id = category.Id,
                            Label = GetLabel(category.Label, language)
                        }
                    },
                    Symptoms = symptoms.Select(s => new SymptomDto
                    {
                        Id = s.Id,
                        Label = GetLabel(s.Label, language)
                    }).ToList()
                });
            }

            var remedies = await _remedyRepository.GetByMedicationIdAsync(medication.Id);
            var replacedBy = remedies.Select(r => new RemedyAlternativeSimpleDto
            {
                Id = r.Id,
                ElementType = r.ElementType,
                ElementId = r.ElementId,
                Usage = GetLabel(r.Usage, language)
            }).ToList();

            return new MedicationDetailDto
            {
                Id = medication.Id,
                BrandName = GetLabel(medication.BrandName, language),
                GenericName = GetLabel(medication.GenericName, language),
                UsedFor = problems,
                ReplacedBy = replacedBy
            };
        }

        private static string GetLabel(Label label, string language)
        {
            return language switch
            {
                "pt" => label.Pt ?? label.En ?? string.Empty,
                "es" => label.Es ?? label.En ?? string.Empty,
                _ => label.En ?? string.Empty
            };
        }

        private static bool IsValidLanguage(string lang)
        {
            return lang == "en" || lang == "pt" || lang == "es";
        }
    }
}
