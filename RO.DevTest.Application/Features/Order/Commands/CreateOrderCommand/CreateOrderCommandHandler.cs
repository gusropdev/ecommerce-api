using MediatR;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Domain.Exception;

namespace RO.DevTest.Application.Features.Order.Commands.CreateOrderCommand;

public class CreateOrderCommandHandler (IOrderRepository orderRepository, ICustomerRepository customerRepository, IProductRepository productRepository) 
    : IRequestHandler<CreateOrderCommandRequest, CreateOrderResult>
{
    public async Task<CreateOrderResult> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetAsync(c => c.Id == request.CustomerId);
        if(customer == null)
            throw new BadRequestException("Cliente não encontrado");

        // Busca os produtos passados pelo request no banco e valida se existe no banco, se está ativo e se há estoque suficiente
        var products = new List<Domain.Entities.Product>();
        foreach (var item in request.Items)
        {
            var product = await productRepository.GetAsync(p => p.Id == item.ProductId);
            if (product == null)
                throw new Exception($"Produto com ID {item.ProductId} não encontrado.");

            if (product.IsActive == false)
                throw new Exception($"O produto {product.Name} está inativo.");
            
            if (product.StockQuantity < item.Quantity)
                throw new Exception($"Estoque insuficiente para o produto {product.Name}.");
            
            products.Add(product);
        }

        //Cria a lista de OrderItems utilizando a lista de Products criada acima, para envetualmente fazer a criação da Order
        var orderItems = request.Items.Select(item =>
        {
            var product = products.FirstOrDefault(p => p.Id == item.ProductId);

            return new OrderItem
            {
                ProductId = product!.Id,
                Quantity = item.Quantity,
                UnitPrice = product.Price
            };
        }).ToList();
        
        var totalValue = orderItems.Sum(i => i.Subtotal);
        
        var order = new Domain.Entities.Order
        {
            CustomerId = customer.Id,
            Items = orderItems,
            TotalValue = totalValue
        };
        
        await orderRepository.CreateAsync(order, cancellationToken);
        
        //Reduz o estoque
        foreach (var item in request.Items)
        {
            var product = products.FirstOrDefault(p => p.Id == item.ProductId);
            product!.StockQuantity -= item.Quantity;
            await productRepository.UpdateAsync(product);
        }
        
        return new CreateOrderResult("Pedido criado com sucesso.", order.Id, order.TotalValue, order.CreatedAt);
    }
}