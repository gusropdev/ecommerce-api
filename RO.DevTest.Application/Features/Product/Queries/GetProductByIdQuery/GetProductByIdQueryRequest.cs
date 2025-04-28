using MediatR;

namespace RO.DevTest.Application.Features.Product.Queries.GetProductByIdQuery;

public class GetProductByIdQueryRequest(Guid productId) : IRequest<GetProductByIdResult>
{
    public Guid ProductId { get; set; } = productId;
}