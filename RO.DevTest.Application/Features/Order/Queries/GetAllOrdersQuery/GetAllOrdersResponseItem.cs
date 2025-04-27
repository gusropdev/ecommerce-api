namespace RO.DevTest.Application.Features.Order.Queries.GetAllOrdersQuery;

public record GetAllOrdersResponseItem (Guid OrderId, decimal TotalValue, DateTime OrderDate)
{
    
}