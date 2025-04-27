using MediatR;

namespace RO.DevTest.Application.Features.Product.Queries.GetAllProductsQuery;

public class GetAllProductsQueryRequest : IRequest<GetAllProductsResult>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SearchTerm { get; set; } 
    public string? OrderBy { get; set; }
    public bool Ascending { get; set; } = true;
}