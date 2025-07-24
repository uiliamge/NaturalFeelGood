
using MediatR;
using NaturalFeelGood.Domain.Entities;

namespace NaturalFeelGood.Application.Features.ElementTypes.Commands
{
    public record CreateElementTypeCommand(ElementType ElementType) : IRequest<Unit>;
}
