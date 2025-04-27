using MediatR;

namespace RO.DevTest.Application.Features.Order.Queries.GetAllOrdersQuery;

public class GetAllOrdersQueryRequest : IRequest<GetAllOrdersResult>
{
    public Guid CustomerId { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SearchTerm { get; set; } 
    public string? OrderBy { get; set; }
    public bool Ascending { get; set; } = true;
}