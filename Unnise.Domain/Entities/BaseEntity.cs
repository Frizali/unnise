namespace Unnise.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        protected BaseEntity(Guid id)
        {
            Id = id;
        }

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
