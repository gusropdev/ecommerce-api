using MediatR;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Exception;

namespace RO.DevTest.Application.Features.Product.Commands.DeleteProductCommand;

public class DeleteProductCommandHandler (IProductRepository productRepository)
    : IRequestHandler<DeleteProductCommandRequest, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetAsync(p => p.Id == request.ProductId);
        
        if (product == null)
            throw new BadRequestException("Produto não encontrado");
        
        await productRepository.DeleteAsync(product);
        
        return new DeleteProductResult("Produto apagado com sucesso", product.Id, product.Name, product.Description);
    }
}