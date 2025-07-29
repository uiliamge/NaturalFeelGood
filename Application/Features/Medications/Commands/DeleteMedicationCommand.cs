using MediatR;
using NaturalFeelGood.Domain.Interfaces;

namespace NaturalFeelGood.Application.Features.Medications.Commands
{     
    public class DeleteMedicationCommand : IRequest
    {
        public string Id { get; }

        public DeleteMedicationCommand(string id)
        {
            Id = id;
        }

        public class Handler : IRequestHandler<DeleteMedicationCommand>
        {
            private readonly IMedicationRepository _repository;

            public Handler(IMedicationRepository repository)
            {
                _repository = repository;
            }

            public async Task Handle(DeleteMedicationCommand request, CancellationToken cancellationToken)
            {
                await _repository.DeleteAsync(request.Id, cancellationToken);
            }
        }
    }
}
