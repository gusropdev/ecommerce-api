namespace RO.DevTest.Application.Features.Customer.Commands.DeleteCustomerCommand;

public record DeleteCustomerResult(string Message, Guid CustomerId, string Name, string UserName, string Email)
{
    
}