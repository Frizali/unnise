namespace Unnise.Application.Abstractions.Security
{
    public interface ICurrentUser
    {
        Guid Id { get; }
        string Email { get; }
        string GlobalName { get;}
    }
}
