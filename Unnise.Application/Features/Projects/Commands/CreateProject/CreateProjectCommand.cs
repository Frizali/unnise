using MediatR;
using Unnise.Domain.Enums;

namespace Unnise.Application.Features.Projects.Commands.CreateProject
{
    public record CreateProjectCommand(string Name, string? Description, ProjectVisibility Visibility) : IRequest;
}
