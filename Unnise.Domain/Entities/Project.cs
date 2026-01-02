namespace Unnise.Domain.Entities
{
    public class Project : BaseEntity
    {
        public Guid OwnerId { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MyProperty { get; set; }
    }
}
