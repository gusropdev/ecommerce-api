using MediatR;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Application.Features.Order.Commands.CreateOrderCommand;
using RO.DevTest.Domain.Exception;

namespace RO.DevTest.Application.Features.Product.Commands.CreateProductCommand;

public class CreateProductCommandHandler (IProductRepository productRepository)
    : IRequestHandler<CreateProductCommandRequest, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateProductCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new BadRequestException(validationResult);
        
        var product = new Domain.Entities.Product
        {
            Name = request.Name,
            Description = request.Description
        };
        
        await productRepository.CreateAsync(product, cancellationToken);
        
        return new CreateProductResult("Produto criado com sucesso", product.Id, product.Name, product.Description);
    }
}