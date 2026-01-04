namespace Unnise.Domain.Entities
{
    public abstract class BaseEntity(Guid id)
    {
        public Guid Id { get; protected set; } = id;
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        protected void MarkCreated()
        {
            CreatedAt = DateTime.Now;
        }

        protected void MarkUpdated()
        {
            UpdatedAt = DateTime.Now;
        }
    }

}
