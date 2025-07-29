using Application.Features.Medications.Dtos;
using MediatR;
using NaturalFeelGood.Domain.Interfaces;

namespace NaturalFeelGood.Application.Features.Medications.Commands
{
    public class UpdateMedicationCommand : IRequest
    {
        public string Id { get; }
        public UpdateMedicationDto Dto { get; }

        public UpdateMedicationCommand(string id, UpdateMedicationDto dto)
        {
            Id = id;
            Dto = dto;
        }

        public class Handler : IRequestHandler<UpdateMedicationCommand>
        {
            private readonly IMedicationRepository _repository;

            public Handler(IMedicationRepository repository)
            {
                _repository = repository;
            }

            public async Task Handle(UpdateMedicationCommand request, CancellationToken cancellationToken)
            {
                await _repository.UpdateAsync(request.Id, request.Dto, cancellationToken);
            }
        }
    }

}
