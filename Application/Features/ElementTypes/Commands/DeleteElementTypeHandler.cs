
using MediatR;
using NaturalFeelGood.Domain.Interfaces;

namespace NaturalFeelGood.Application.Features.ElementType.Commands
{
    public class DeleteElementTypeHandler : IRequestHandler<DeleteElementTypeCommand, Unit>
    {
        private readonly IElementTypeRepository _repository;

        public DeleteElementTypeHandler(IElementTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteElementTypeCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
