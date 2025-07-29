using MediatR;
using NaturalFeelGood.Domain.Entities;
using NaturalFeelGood.Domain.Interfaces;

namespace NaturalFeelGood.Application.Features.ElementTypes.Commands
{
    public class UpdateElementTypeCommand : IRequest<Unit>
    {
        public string Id { get; set; } = string.Empty;
        public ElementType UpdatedElementType { get; set; } = new();
    }

    public class UpdateElementTypeCommandHandler : IRequestHandler<UpdateElementTypeCommand, Unit>
    {
        private readonly IElementTypeRepository _repository;

        public UpdateElementTypeCommandHandler(IElementTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateElementTypeCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateAsync(request.Id, request.UpdatedElementType, cancellationToken);
            return Unit.Value;
        }
    }
}
