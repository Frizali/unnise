using Unnise.Domain.Exceptions;

namespace Unnise.Domain.Entities
{
    public class User: BaseEntity
    {
        public string Username { get; private set; }
        public string GlobalName { get; private set; }
        public string Email { get; private set; }

        public string? Phone { get; private set; }
        public string? Bio { get; private set; }
        public string? Avatar { get; private set; }
        public string? Banner { get; private set; }
        public string? BannerColor { get; private set; }

        public string PasswordHash { get; private set; }

        public bool IsVerified { get; private set; }
        public bool IsActive { get; private set; }

        public DateTime? LastLoginAt { get; private set; }

        public User(
            string username,
            string globalName,
            string email,
            string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new DomainException("Username wajib diisi");

            if (string.IsNullOrWhiteSpace(email))
                throw new DomainException("Email wajib diisi");

            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new DomainException("Password hash tidak valid");

            Id = Guid.NewGuid();
            Username = username;
            GlobalName = globalName;
            Email = email;
            PasswordHash = passwordHash;

            IsActive = true;
            IsVerified = false;

            CreatedAt = DateTime.UtcNow;
        }

        public void Verify()
        {
            if (IsVerified)
                throw new DomainException("User sudah terverifikasi");

            IsVerified = true;
            TouchUpdate();
        }

        public void Deactivate()
        {
            if (!IsActive)
                throw new DomainException("User sudah nonaktif");

            IsActive = false;
            TouchUpdate();
        }

        public void Activate()
        {
            if (IsActive)
                throw new DomainException("User sudah aktif");

            IsActive = true;
            TouchUpdate();
        }

        public void UpdateProfile(
            string? globalName,
            string? bio,
            string? avatar,
            string? banner,
            string? bannerColor,
            string? phone)
        {
            GlobalName = globalName ?? GlobalName;
            Bio = bio;
            Avatar = avatar;
            Banner = banner;
            BannerColor = bannerColor;
            Phone = phone;

            TouchUpdate();
        }

        public void RecordLogin()
        {
            LastLoginAt = DateTime.UtcNow;
        }
    }
}
