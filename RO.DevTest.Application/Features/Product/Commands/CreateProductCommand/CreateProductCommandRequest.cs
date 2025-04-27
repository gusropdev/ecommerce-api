using MediatR;
using RO.DevTest.Application.Features.Order.Commands.CreateOrderCommand;

namespace RO.DevTest.Application.Features.Product.Commands.CreateProductCommand;

public class CreateProductCommandRequest : IRequest<CreateProductResult>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
}