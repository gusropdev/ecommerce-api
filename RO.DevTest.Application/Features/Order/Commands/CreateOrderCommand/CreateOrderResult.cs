using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Application.Features.Order.Commands.CreateOrderCommand;

public record CreateOrderResult (string Message, Guid OrderId, decimal TotalValue, DateTime CreatedAt)
{
    
}