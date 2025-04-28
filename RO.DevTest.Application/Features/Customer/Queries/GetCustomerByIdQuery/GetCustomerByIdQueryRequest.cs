using MediatR;

namespace RO.DevTest.Application.Features.Customer.Queries.GetCustomerByIdQuery;

public class GetCustomerByIdQueryRequest (Guid customerId) : IRequest<GetCustomerByIdResult>
{
    public Guid CustomerId { get; set; }  = customerId;
}