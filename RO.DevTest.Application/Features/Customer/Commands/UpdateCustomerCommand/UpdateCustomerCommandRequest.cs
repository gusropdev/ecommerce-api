using MediatR;

namespace RO.DevTest.Application.Features.Customer.Commands.UpdateCustomerCommand;

public class UpdateCustomerCommandRequest : IRequest<UpdateCustomerResult>
{
    public string UserId { get; set; }

    public string Name { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    
    
}