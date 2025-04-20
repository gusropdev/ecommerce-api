namespace RO.DevTest.Domain.Entities;

public class Order
{
    public Guid Id { get; set; }

    public string CustomerId { get; set; } = null!;
    public Customer Customer { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public decimal TotalValue { get; set; }
    
    public List<OrderItem> Items { get; set; } = [];
}