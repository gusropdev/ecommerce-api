using MediatR;

namespace RO.DevTest.Application.Features.Product.Commands.DeleteProductCommand;

public class DeleteProductCommandRequest(Guid productId) : IRequest<DeleteProductResult>
{
    public Guid ProductId { get; set; } = productId;
}