
using AutoMapper;
using MediatR;
using NaturalFeelGood.Domain.Interfaces;

namespace NaturalFeelGood.Application.Features.ElementType.Commands
{
    public class UpdateElementTypeHandler : IRequestHandler<UpdateElementTypeCommand, Unit>
    {
        private readonly IElementTypeRepository _repository;
        private readonly IMapper _mapper;

        public UpdateElementTypeHandler(IElementTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateElementTypeCommand request, CancellationToken cancellationToken)
        {
            var updated = _mapper.Map<Domain.Entities.ElementType>(request.Element);
            updated.Id = request.Id;
            await _repository.UpdateAsync(request.Id, updated);
            return Unit.Value;
        }
    }
}
