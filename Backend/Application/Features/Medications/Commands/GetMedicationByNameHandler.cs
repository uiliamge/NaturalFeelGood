using Application.Features.BodySystem.Dtos;
using Application.Features.Medications.Dtos;
using Application.Features.Organ;
using Application.Features.Problem.Dtos;
using Application.Features.NaturalElement.Dtos;
using Application.Features.Symptom.Dtos;
using MediatR;
using NaturalFeelGood.Application.Features.Medications.Queries;
using NaturalFeelGood.Domain.Common;
using NaturalFeelGood.Domain.Entities;
using NaturalFeelGood.Domain.Interfaces;
using System.Globalization;

namespace NaturalFeelGood.Application.Features.Medications.Handlers
{
    public class GetMedicationByNameHandler : IRequestHandler<GetMedicationByNameQuery, MedicationDetailDto?>
    {
        private readonly IMedicationRepository _medicationRepository;
        private readonly IProblemRepository _problemRepository;
        private readonly IOrganRepository _organRepository;
        private readonly IBodySystemRepository _bodySystemRepository;
        private readonly ISymptomRepository _symptomRepository;
        private readonly INaturalElementRepository _naturalElementRepository;

        public GetMedicationByNameHandler(
            IMedicationRepository medicationRepository,
            IProblemRepository problemRepository,
            IOrganRepository organRepository,
            IBodySystemRepository bodySystemRepository,
            ISymptomRepository symptomRepository,
            INaturalElementRepository naturalElement)
        {
            _medicationRepository = medicationRepository;
            _problemRepository = problemRepository;
            _organRepository = organRepository;
            _bodySystemRepository = bodySystemRepository;
            _symptomRepository = symptomRepository;
            _naturalElementRepository = naturalElement;
        }

        public async Task<MedicationDetailDto?> Handle(GetMedicationByNameQuery request, CancellationToken cancellationToken)
        {
            var medication = await _medicationRepository.GetByBrandOrGenericNameAsync(request.Name);
            if (medication is null) return null;

            // Use current UI culture or fallback to "en"
            string language = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            if (string.IsNullOrWhiteSpace(language) || !LanguageHelper.IsValidLanguage(language))
                language = "en";

            var problems = new List<ProblemDto>();
            foreach (var problemId in medication.Problems)
            {
                var problem = await _problemRepository.GetByIdAsync(problemId, cancellationToken);
                if (problem == null) continue;

                var organ = await _organRepository.GetByIdAsync(problem.OrganId, cancellationToken);
                var bodySystem = organ != null ? await _bodySystemRepository.GetByIdAsync(organ.BodySystemId, cancellationToken) : null;
                var symptoms = await _symptomRepository.GetByIdsAsync(problem.SymptomsIds);

                problems.Add(new ProblemDto
                {
                    Id = problem.Id,
                    Label = problem.Label.Get(language),
                    Organ = organ == null ? null : new OrganDto
                    {
                        Id = organ.Id,
                        Label = organ.Label.Get(language),
                        BodySystem = bodySystem == null ? null : new BodySystemDto
                        {
                            Id = bodySystem.Id,
                            Label = bodySystem.Label.Get(language)
                        }
                    },
                    Symptoms = symptoms.Select(s => new SymptomDto
                    {
                        Id = s.Id,
                        Label = s.Label.Get(language)
                    }).ToList()
                });
            }

            IEnumerable<NaturalElement> remedies = await _naturalElementRepository.GetByMedicationIdAsync(medication.Id);
            var replacedBy = remedies.Select(r => new NaturalElementSimpleDto
            {
                Id = r.Id,
                ElementType = r.Type,
                ElementId = r.Id,
                Label = r.Label.Get(language)
            }).ToList();

            return new MedicationDetailDto
            {
                Id = medication.Id,
                BrandName = medication.BrandName.Get(language),
                GenericName = medication.GenericName.Get(language),
                UsedFor = problems,
                ReplacedBy = replacedBy
            };
        }
                
    }
}
