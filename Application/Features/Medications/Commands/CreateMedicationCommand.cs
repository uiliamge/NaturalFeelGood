using MediatR;
using NaturalFeelGood.Domain.Entities;
using NaturalFeelGood.Domain.Interfaces;

namespace NaturalFeelGood.Application.Features.Medications.Commands
{
    public class CreateMedicationCommand : IRequest
    {
        public Medication Medication { get; }

        public CreateMedicationCommand(Medication medication)
        {
            Medication = medication;
        }

        public class Handler : IRequestHandler<CreateMedicationCommand>
        {
            private readonly IMedicationRepository _repository;

            public Handler(IMedicationRepository repository)
            {
                _repository = repository;
            }

            public async Task Handle(CreateMedicationCommand request, CancellationToken cancellationToken)
            {
                await _repository.AddAsync(request.Medication, cancellationToken);
            }
        }
    }

}
