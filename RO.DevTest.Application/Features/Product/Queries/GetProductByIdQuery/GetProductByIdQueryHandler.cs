using MediatR;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Exception;

namespace RO.DevTest.Application.Features.Product.Queries.GetProductByIdQuery;

public class GetProductByIdQueryHandler(IProductRepository productRepository)
    : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetAsync(p => p.Id == request.ProductId);

        if (product == null)
            throw new BadRequestException("Produto não encontrado");
        
        return new GetProductByIdResult(product.Id, product.Name, product.Description, product.Price, product.StockQuantity, product.IsActive);
    }
}