namespace Unnise.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? UpdateAt { get; protected set; }

        protected void TouchUpdate()
        {
            UpdateAt = DateTime.UtcNow;
        }
    }
}
