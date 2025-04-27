using MediatR;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Exception;

namespace RO.DevTest.Application.Features.Product.Commands.UpdateProductCommand;

public class UpdateProductCommandHandler (IProductRepository productRepository)
    : IRequestHandler<UpdateProductCommandRequest, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdateProductCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new BadRequestException(validationResult);
        
        
        var product = await productRepository.GetAsync(p => p.Id == request.ProductId);
        if (product == null)
            throw new BadRequestException("Produto não encontado");
        
        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;
        product.StockQuantity = request.StockQuantity;
        product.IsActive = request.IsActive;
        
        await productRepository.UpdateAsync(product);
        
        return new UpdateProductResult(
            "Produto atualizado com sucesso.",
            product.Id,
            product.Name,
            product.Description,
            product.Price,
            product.StockQuantity,
            product.IsActive);
        
    }
}