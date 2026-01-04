namespace Unnise.Application.Abstractions.Persistence
{
    public interface IProjectRepository
    {
        Task<bool> IsNameUniqueAsync(string name);
    }
}
