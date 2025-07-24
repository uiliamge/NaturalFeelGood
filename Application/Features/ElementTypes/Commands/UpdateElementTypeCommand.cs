
using MediatR;
using NaturalFeelGood.Application.Features.ElementTypes.Dtos;

namespace NaturalFeelGood.Application.Features.ElementTypes.Commands
{
    public record UpdateElementTypeCommand(string Id, UpdateElementTypeDto Element) : IRequest<Unit>;
}
