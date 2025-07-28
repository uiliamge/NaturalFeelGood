
using MediatR;
using NaturalFeelGood.Domain.Entities;
using NaturalFeelGood.Domain.Interfaces;

namespace NaturalFeelGood.Application.Features.Problems.Queries
{
    public record GetAllProblemsQuery : IRequest<List<Problem>>;

    public class GetAllProblemsHandler : IRequestHandler<GetAllProblemsQuery, List<Problem>>
    {
        private readonly IProblemRepository _repository;

        public GetAllProblemsHandler(IProblemRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Problem>> Handle(GetAllProblemsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
