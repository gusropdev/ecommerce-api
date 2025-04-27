using MediatR;

namespace RO.DevTest.Application.Features.Order.Queries.GetOrderByIdQuery;

public class GetOrderByIdQueryRequest (Guid orderId): IRequest<GetOrderByIdResult>
{
    public Guid OrderId { get; set; } = orderId;
}