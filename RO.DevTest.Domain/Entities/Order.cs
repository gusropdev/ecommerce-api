using RO.DevTest.Domain.Abstract;

namespace RO.DevTest.Domain.Entities;

public class Order : BaseEntity
{
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    
    public decimal TotalValue { get; set; }
    
    public List<OrderItem> Items { get; set; } = [];
}