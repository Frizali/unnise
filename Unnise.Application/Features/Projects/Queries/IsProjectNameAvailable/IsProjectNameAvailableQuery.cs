using MediatR;

namespace Unnise.Application.Features.Projects.Queries.IsProjectNameAvailable
{
    public record IsProjectNameAvailableQuery(string Name) : IRequest<IsProjectNameAvailableResult>;
}
