using MediatR;
using RO.DevTest.Application.Contracts.Persistance.Repositories;

namespace RO.DevTest.Application.Features.Order.Queries.GetOrderByIdQuery;

public class GetOrderByIdQueryHandler (IOrderRepository orderRepository)
    : IRequestHandler<GetOrderByIdQueryRequest, GetOrderByIdResult>
{
    public async Task<GetOrderByIdResult> Handle(GetOrderByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetAsync(o => o.Id == request.OrderId, o => o.Items);
        if (order == null)
            throw new Exception("Pedido não encontrado.");

        var orderItems = order.Items.Select(item => new OrderItemResult
        {
            ProductId = item.ProductId,
            UnitPrice = item.UnitPrice,
            Quantity = item.Quantity
        }).ToList();

        return new GetOrderByIdResult(order.Id, order.CustomerId, order.TotalValue, order.CreatedAt, orderItems);

    }
}