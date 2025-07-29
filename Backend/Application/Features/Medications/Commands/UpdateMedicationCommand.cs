using Application.Features.Medications.Dtos;
using AutoMapper;
using MediatR;
using NaturalFeelGood.Domain.Entities;
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
            private readonly IMapper _mapper;

            public Handler(IMedicationRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(UpdateMedicationCommand request, CancellationToken cancellationToken)
            {
                var updatedMedication = _mapper.Map<Medication>(request.Dto);
                updatedMedication.Id = request.Id;
                await _repository.UpdateAsync(request.Id, updatedMedication, cancellationToken);
            }
        }
    }

}
