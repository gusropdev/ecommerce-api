namespace RO.DevTest.Application.Features.Product.Commands.DeleteProductCommand;

public record DeleteProductResult(string Message, Guid ProductId, string Name, string Description)
{
    
}