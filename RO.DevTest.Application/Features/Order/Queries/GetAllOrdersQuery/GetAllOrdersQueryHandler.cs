using System.Linq.Expressions;
using MediatR;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Exception;

namespace RO.DevTest.Application.Features.Order.Queries.GetAllOrdersQuery;

public class GetAllOrdersQueryHandler (IOrderRepository orderRepository, ICustomerRepository customerRepository) 
    : IRequestHandler<GetAllOrdersQueryRequest, GetAllOrdersResult>
{
    public async Task<GetAllOrdersResult> Handle(GetAllOrdersQueryRequest request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetAsync(c => c.Id == request.CustomerId);
        if (customer == null)
            throw new BadRequestException("Cliente não encontrado");
        
        var filter = BuildFilter(request.CustomerId);
        var orderBy = BuildOrderBy(request.OrderBy, request.Ascending);

        var totalCount = await orderRepository.CountAsync(filter);

        var orders = await orderRepository.GetAllAsync(
            filter,
            orderBy,
            (request.PageNumber - 1) * request.PageSize,
            request.PageSize
        );

        var orderItems = orders.Select(o => new GetAllOrdersResponseItem(
            o.Id,
            o.TotalValue,
            o.CreatedAt
        )).ToList();

        return new GetAllOrdersResult(request.CustomerId, totalCount, orderItems);
    }
    private static Expression<Func<Domain.Entities.Order, bool>> BuildFilter(Guid customerId)
    {
        return o => o.CustomerId == customerId;
    }
    private static Func<IQueryable<Domain.Entities.Order>, IOrderedQueryable<Domain.Entities.Order>> BuildOrderBy(string? orderBy, bool ascending)
    {
        return orderBy?.ToLower() switch
        {
            "totalvalue" => ascending 
                ? q => q.OrderBy(o => o.TotalValue)
                : q => q.OrderByDescending(o => o.TotalValue),
            "orderdate" => ascending
                ? q => q.OrderBy(o => o.CreatedAt)
                : q => q.OrderByDescending(o => o.CreatedAt),
            
            _ => q => q.OrderBy(c => c.Id)
        };
    }
}