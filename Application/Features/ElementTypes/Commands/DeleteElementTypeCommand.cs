
using MediatR;

namespace NaturalFeelGood.Application.Features.ElementTypes.Commands
{
    public record DeleteElementTypeCommand(string Id) : IRequest<Unit>;
}
