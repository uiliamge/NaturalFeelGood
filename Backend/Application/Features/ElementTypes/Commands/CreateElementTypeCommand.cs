using MediatR;
using NaturalFeelGood.Domain.Entities;
using NaturalFeelGood.Domain.Interfaces;

namespace NaturalFeelGood.Application.Features.ElementTypes.Commands
{
    public class CreateElementTypeCommand : IRequest<Unit>
    {
        public ElementType ElementType { get; set; } = new();
    }

    public class CreateElementTypeCommandHandler : IRequestHandler<CreateElementTypeCommand, Unit>
    {
        private readonly IElementTypeRepository _repository;

        public CreateElementTypeCommandHandler(IElementTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateElementTypeCommand request, CancellationToken cancellationToken)
        {
            await _repository.InsertAsync(request.ElementType, cancellationToken);
            return Unit.Value;
        }
    }
}