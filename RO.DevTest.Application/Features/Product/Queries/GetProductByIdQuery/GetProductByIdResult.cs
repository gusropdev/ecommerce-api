namespace RO.DevTest.Application.Features.Product.Queries.GetProductByIdQuery;

public record GetProductByIdResult(Guid ProductId, string Name, string Description, decimal Price, int StockQuantity, bool IsActive)
{
    
}