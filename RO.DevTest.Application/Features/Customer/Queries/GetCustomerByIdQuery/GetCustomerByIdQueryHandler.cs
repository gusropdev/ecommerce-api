using MediatR;
using RO.DevTest.Application.Contracts.Infrastructure;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Exception;

namespace RO.DevTest.Application.Features.Customer.Queries.GetCustomerByIdQuery;

public class GetCustomerByIdQueryHandler (ICustomerRepository customerRepository) 
    : IRequestHandler<GetCustomerByIdQueryRequest, GetCustomerByIdResult>
{
    public async Task<GetCustomerByIdResult> Handle(GetCustomerByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetAsync(c => c.Id == request.CustomerId, c => c.User);
        
        if (customer == null)
            throw new BadRequestException("Cliente não encontrado");

        var user = customer.User;
        
        return new GetCustomerByIdResult(customer.Id, user.Name, user.UserName!, user.Email!, customer.Orders);
    }
}