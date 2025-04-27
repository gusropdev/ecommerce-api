namespace RO.DevTest.Application.Features.Order.Queries.GetAllOrdersQuery;

public record GetAllOrdersResult (Guid CustomerId, int TotalCount, List<GetAllOrdersResponseItem> Orders)
{
    
}