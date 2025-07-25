
using MediatR;

namespace NaturalFeelGood.Application.Features.ElementType.Commands
{
    public record DeleteElementTypeCommand(string Id) : IRequest<Unit>;
}
