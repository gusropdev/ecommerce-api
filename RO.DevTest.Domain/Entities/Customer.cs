namespace RO.DevTest.Domain.Entities;

public class Customer
{
    public Guid Id { get; set; }

    public string UserId { get; set; } = null!;
    public User User { get; set; } = null!;
    
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
    public List<Order> Orders { get; set; } = [];

}