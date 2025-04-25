namespace RO.DevTest.Domain.Abstract;
public abstract class BaseEntity {
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt{ get; set; } = DateTime.UtcNow;
    public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;

    protected BaseEntity() { }
}
