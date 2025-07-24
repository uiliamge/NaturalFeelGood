using MediatR;
using NaturalFeelGood.Domain.Interfaces;

namespace NaturalFeelGood.Application.Features.ElementTypes.Commands
{
    /// <summary>
    /// Handles creation of ElementType.
    /// </summary>
    public class CreateElementTypeHandler : IRequestHandler<CreateElementTypeCommand, Unit>
    {
        private readonly IElementTypeRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateElementTypeHandler"/> class.
        /// </summary>
        /// <param name="repository">The element type repository.</param>
        public CreateElementTypeHandler(IElementTypeRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handles the creation of an ElementType.
        /// </summary>
        /// <param name="request">The create command.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Unit"/> value.</returns>
        public async Task<Unit> Handle(CreateElementTypeCommand request, CancellationToken cancellationToken)
        {
            await _repository.InsertAsync(request.ElementType);
            return Unit.Value;
        }
    }
}
