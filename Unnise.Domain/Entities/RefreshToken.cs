namespace Unnise.Domain.Entities
{
    public class RefreshToken
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string Token { get; private set; }
        public DateTime ExpiresAt { get; private set; }
        public DateTime? RevokedAt { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string? ReplaceByToken { get; private set; }
        public bool IsExpired => DateTime.UtcNow >= ExpiresAt;
        public bool IsActive => RevokedAt == null && !IsExpired;

        public RefreshToken(Guid id, Guid userId, string token, DateTime createdAt, DateTime expiresAt)
        {
            Id = id;
            UserId = userId;
            Token = token;
            CreatedAt = createdAt;
            ExpiresAt = expiresAt;
        }

        public void RevokeToken()
        {
            RevokedAt = DateTime.Now;
        }

        public void ReplaceToken(string replaceByToken)
        {
            ReplaceByToken = replaceByToken;
        }
    }
}
