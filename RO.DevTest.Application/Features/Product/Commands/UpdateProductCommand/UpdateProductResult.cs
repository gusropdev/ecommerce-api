namespace RO.DevTest.Application.Features.Product.Commands.UpdateProductCommand;

public record UpdateProductResult (string Message, Guid ProductId, string Name, string Description, decimal Price, int StockQuantity, bool IsActive)
{
    
}