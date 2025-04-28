namespace RO.DevTest.Application.Features.Order.Queries.GetOrderByIdQuery;

public record GetOrderByIdResult (Guid OrderId, Guid CustomerId, decimal TotalValue, DateTime CreatedAt, List<OrderItemResult> Items)
{
}

public class OrderItemResult
{
    public Guid ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}