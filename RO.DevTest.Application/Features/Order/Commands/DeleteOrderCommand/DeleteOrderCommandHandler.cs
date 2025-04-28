using MediatR;
using RO.DevTest.Application.Contracts.Persistance.Repositories;

namespace RO.DevTest.Application.Features.Order.Commands.DeleteOrderCommand;

public class DeleteOrderCommandHandler (IOrderRepository orderRepository) 
    : IRequestHandler<DeleteOrderCommandRequest, DeleteOrderResult>
{
    public async Task<DeleteOrderResult> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetAsync(o => o.Id == request.OrderId);
        if (order == null)
            throw new Exception("Pedido não encontrado.");
        
        await orderRepository.DeleteAsync(order);
        return new DeleteOrderResult("Pedido apagado com sucesso", order.Id);
    }
}