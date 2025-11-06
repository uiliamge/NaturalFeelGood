using Amazon.DynamoDBv2.Model;
using Application.Features.Problem.Dtos;
using AutoMapper;
using MediatR;
using NaturalFeelGood.Domain.Interfaces;
using System.Text.Json;

namespace NaturalFeelGood.Application.Features.HealthProblems.Queries
{
    // ✅ Agora a Query aceita parâmetros de paginação
    public record GetPaginatedProblemsQuery(
        string? OrganId,
        int PageSize = 10,
        string? LastKey = null
    ) : IRequest<PaginatedProblemsResult>;

    // ✅ Retorno inclui lista e token da próxima página
    public record PaginatedProblemsResult(List<ProblemDto> Items, string? NextKey);

    public class GetPaginatedProblemsHandler
        : IRequestHandler<GetPaginatedProblemsQuery, PaginatedProblemsResult>
    {
        private readonly IProblemRepository _repository;
        private readonly IMapper _mapper;

        public GetPaginatedProblemsHandler(IProblemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedProblemsResult> Handle(GetPaginatedProblemsQuery request, CancellationToken cancellationToken)
        {
            // 🔹 Desserializa o token recebido do frontend (caso exista)
            Dictionary<string, AttributeValue>? lastKey = null;
            if (!string.IsNullOrEmpty(request.LastKey))
            {
                lastKey = JsonSerializer.Deserialize<Dictionary<string, AttributeValue>>(request.LastKey);
            }

            // 🔹 Busca página atual no repositório
            var (entities, nextKey) = await _repository.GetPaginatedAsync(
                request.PageSize,
                lastKey,
                cancellationToken
            );

            // 🔹 Aplica filtros opcionais (caso venham da query)
            if (!string.IsNullOrEmpty(request.OrganId))
                entities = entities.Where(e => e.OrganId == request.OrganId).ToList();

            // 🔹 Converte entidades para DTOs
            var dtos = _mapper.Map<List<ProblemDto>>(entities);

            // 🔹 Serializa o próximo token para retornar ao frontend
            string? nextKeyJson = nextKey != null && nextKey.Count > 0
                ? JsonSerializer.Serialize(nextKey)
                : null;

            return new PaginatedProblemsResult(dtos, nextKeyJson);
        }
    }
}
