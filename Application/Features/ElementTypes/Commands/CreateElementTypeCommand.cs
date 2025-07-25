
using MediatR;

namespace NaturalFeelGood.Application.Features.ElementType.Commands
{
    /// <summary>
    /// Command to create a new ElementType entity.
    /// </summary>
    public record CreateElementTypeCommand(Domain.Entities.ElementType ElementType) : IRequest<Unit>;
}
