using MediatR;

namespace RO.DevTest.Application.Features.Customer.Commands.DeleteCustomerCommand;

public class DeleteCustomerCommandRequest(Guid customerId) : IRequest<DeleteCustomerResult>
{
    public Guid CustomerId { get; set; } = customerId;
}