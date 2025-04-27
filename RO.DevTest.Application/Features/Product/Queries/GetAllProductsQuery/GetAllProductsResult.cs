namespace RO.DevTest.Application.Features.Product.Queries.GetAllProductsQuery;

public record GetAllProductsResult (int TotalCount, List<Domain.Entities.Product> Products)
{
    
}