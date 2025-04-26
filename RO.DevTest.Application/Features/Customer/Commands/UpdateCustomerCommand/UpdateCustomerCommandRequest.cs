using MediatR;

namespace RO.DevTest.Application.Features.Customer.Commands.UpdateCustomerCommand;

public class UpdateCustomerCommandRequest : IRequest<UpdateCustomerResult>
{
    public Guid CustomerId { get; set; }
    public string Address { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
    
}