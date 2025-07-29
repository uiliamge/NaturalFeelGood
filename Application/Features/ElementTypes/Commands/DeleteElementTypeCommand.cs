
using MediatR;
using NaturalFeelGood.Domain.Interfaces;

namespace NaturalFeelGood.Application.Features.ElementTypes.Commands
{
    public class DeleteElementTypeCommand : IRequest<Unit>
    {
        public string Value { get; set; } = string.Empty;
    }

    public class DeleteElementTypeCommandHandler : IRequestHandler<DeleteElementTypeCommand, Unit>
    {
        private readonly IElementTypeRepository _repository;

        public DeleteElementTypeCommandHandler(IElementTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteElementTypeCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Value);
            return Unit.Value;
        }
    }
}
