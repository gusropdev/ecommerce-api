using RO.DevTest.Domain.Abstract;

namespace RO.DevTest.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public bool IsActive { get; set; }
    public List<OrderItem> OrderItems { get; set; } = [];
}