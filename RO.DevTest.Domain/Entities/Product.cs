namespace RO.DevTest.Domain.Entities;

public class Product
{
    public Guid Id{ get; set; }

    public string Name { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }

    public bool IsActive { get; set; } = true;

    public List<OrderItem> OrderItems { get; set; } = [];
}