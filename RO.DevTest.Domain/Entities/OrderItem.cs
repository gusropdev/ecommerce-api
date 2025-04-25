using Microsoft.EntityFrameworkCore.Infrastructure;
using RO.DevTest.Domain.Abstract;

namespace RO.DevTest.Domain.Entities;

public class OrderItem : BaseEntity
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    public decimal Subtotal => Quantity * UnitPrice;
}