using MediatR;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Application.Features.Order.Commands.CreateOrderCommand;

public class CreateOrderCommandRequest : IRequest<CreateOrderResult>
{
    public Guid CustomerId { get; set; }
    public List<CreateOrderItemRequest> Items { get; set; } = null!;
}

public class CreateOrderItemRequest 
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}