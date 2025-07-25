
using MediatR;
using NaturalFeelGood.Application.Features.ElementType.Dtos;

namespace NaturalFeelGood.Application.Features.ElementType.Commands
{
    public record UpdateElementTypeCommand(string Id, UpdateElementTypeDto Element) : IRequest<Unit>;
}
