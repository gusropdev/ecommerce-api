using System.Linq.Expressions;
using MediatR;
using RO.DevTest.Application.Contracts.Persistance.Repositories;

namespace RO.DevTest.Application.Features.Customer.Queries.GetAllCustomersQuery;

public class GetAllCustomerQueryHandler(ICustomerRepository customerRepository) 
    : IRequestHandler<GetAllCustomersQueryRequest, GetAllCustomersResult> 
{
    public async Task<GetAllCustomersResult> Handle(GetAllCustomersQueryRequest request, CancellationToken cancellationToken)
    {
        var filter = BuildFilter(request.SearchTerm);
        var orderBy = BuildOrderBy(request.OrderBy, request.Ascending);

        var totalCount = await customerRepository.CountAsync(filter);

        var customers = await customerRepository.GetAllAsync(
            filter, 
            orderBy,
         (request.PageNumber - 1) * request.PageSize,
            request.PageSize,
            c => c.User
        );
        
        var customerItems = customers.Select
            (c => new GetAllCustomersResponseItem(c.Id, c.User.Name, c.User.UserName!, c.User.Email!)).ToList();

        return new GetAllCustomersResult(totalCount, customerItems);
    }
    
    private static Expression<Func<Domain.Entities.Customer, bool>> BuildFilter(string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return c => true;

        return c => c.User.Name.Contains(searchTerm) || c.User.Email!.Contains(searchTerm);
    }
    private static Func<IQueryable<Domain.Entities.Customer>, IOrderedQueryable<Domain.Entities.Customer>> BuildOrderBy(string? orderBy, bool ascending)
    
    {
        return orderBy?.ToLower() switch
        {
            "name" => ascending 
                ? q => q.OrderBy(c => c.User.Name)
                : q => q.OrderByDescending(c => c.User.Name),
            "email" => ascending
                ? q => q.OrderBy(c => c.User.Email)
                : q => q.OrderByDescending(c => c.User.Email),
            _ => q => q.OrderBy(c => c.Id)
        };
    }

}